param (
    [string]$Configuration = "Debug",
    [string]$GitSha = (git rev-parse HEAD),
    [string]$Timestamp = (Get-Date).ToUniversalTime().ToString('yyyyMMddHHmmss'),
    [string]$RunNumber = "0" # CI-provided build number, or 0 if local build.
)

$ErrorActionPreference = "Stop"

# Derive paths
$RepoRoot = Resolve-Path $PSScriptRoot\..
$BuildArtifactRoot = Join-Path $RepoRoot "/src/SubStyle/bin/$Configuration/net8.0-windows"
$InstallerContentRoot = Join-Path $BuildArtifactRoot "win-x64/publish"
$DistRoot = Join-Path $RepoRoot "dist"

# Derive git info
$GitShaShort = $GitSha.Substring(0,9)
$GitWorkspaceHasChanges = ![string]::IsNullOrEmpty((git status --porcelain))
$GitShaStatus = if ($GitWorkspaceHasChanges) {"(edited)"} else {""}

# dotnet parameters
$DotnetParams = @(
    "--configuration $Configuration",
"") -join " "

Write-Output $DotnetParams

# dotnet parameters
$DotnetPublishParams = @(
    "/p:PublishTrimmed=`"true`""
    "/p:PublishAot=`"true`""
    "/p:IncludeNativeLibrariesForSelfExtract=`"true`""
    "/p:PublishReadyToRun=`"true`""
    "/p:SelfContained=`"True`"",
    "/p:RuntimeIdentifier=`"win-x64`"",
"") -join " "

# Clean workspace
Remove-Item -Confirm:$false -erroraction silentlycontinue -recurse $BuildArtifactRoot
Remove-Item -Confirm:$false -erroraction silentlycontinue -recurse $DistRoot

# Create application
cd $RepoRoot/src
iex ("dotnet clean " + $DotnetParams)
# iex ("dotnet build " + $DotnetParams) # Not sure we need this anymore, as we are doing a publish
iex ("dotnet test " + $DotnetParams)
iex ("dotnet publish " + $DotnetParams + " " + $DotnetPublishParams)
