@REM Not to be run by CI (e.g. .github/workflows/build.yml), which should run the powershell script directly.
@REM
@REM This is for local testing only for ease of manual iteration, to run the build powershell script with example parameters.
@REM
@REM chokidar *.ps1 -c "build-local.bat"
cls
Powershell.exe -executionpolicy remotesigned -File %~dp0build.ps1 -Configuration "Release"
