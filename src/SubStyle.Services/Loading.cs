namespace SubStyle.Services;

using System.IO.Compression;
using SubStyle.Models;
using SubStyle.Sys;

public static class Loading
{
    public static Workspace LoadWorkspace()
    {
        Paths paths = new Paths();

        return Loading.LoadWorkspaceFromPaths(paths);
    }

    public static Pack LoadPackFromDirectory(string directory)
    {
        Pack pack = new Pack()
        {
            Name = new DirectoryInfo(directory).Name,
        };

        var assets = Directory.GetFiles(directory)
            .ToList()
            .Where(x => x.EndsWith(".bm2", StringComparison.OrdinalIgnoreCase))
            .Select(Asset.PathToAsset);

        pack.Assets.SetRange(assets);

        return pack;
    }

    public static Pack LoadPackFromZip(string path)
    {
        Pack pack = new Pack()
        {
            Name = Path.GetFileNameWithoutExtension(path),
        };

        using var fileStream = File.OpenRead(path);
        using ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Read);

        var assets = zipArchive.Entries
            .ToList()
            .Where(x => x.Name.EndsWith(".bm2", StringComparison.OrdinalIgnoreCase))
            .Select(Asset.ZipArchiveEntryToAsset)
            ;

        pack.Assets.SetRange(assets);

        return pack;
    }

    public static Workspace LoadWorkspaceFromPaths(Paths paths)
    {
        Pack rootGraphics = LoadPackFromDirectory(paths.RootGraphicsDir);

        IEnumerable<Pack> mods = paths
            .ListModPaths()
            .ToList()
            .Where(x => x.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            .Select(x => LoadPackFromZip(x))
            ;

        IEnumerable<Pack> scopes = paths
            .ListScopePaths()
            .ToList()
            .Select(x => LoadPackFromDirectory(x))
            ;

        Workspace workspace = new Workspace()
        {
            RootGraphics = rootGraphics,
        };

        workspace.ModPackChoice.Items.SetRange(mods);
        workspace.ScopePackChoice.Items.SetRange(scopes);

        return workspace;
    }
}
