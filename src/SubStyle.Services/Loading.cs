namespace SubStyle.Services;

using System.IO.Compression;
using Avalonia.Media.Imaging;
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
        string[] files = Directory.GetFiles(directory);

        List<Asset> assets = files.ToList().ConvertAll(Asset.PathToAsset);

        Pack pack = new Pack()
        {
            Name = directory,
        };

        pack.Assets.SetRange(assets);

        return pack;
    }

    public static Pack LoadPackFromZip(string path)
    {
        Pack pack = new Pack()
        {
            Name = path,
            Notes = "hmm",
        };

        using var fileStream = File.OpenRead(path);
        using ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Read);

        foreach (ZipArchiveEntry entry in zipArchive.Entries)
        {
            Asset asset = new Asset();
            var name = entry.Name;

            if (name.EndsWith(".bM2", StringComparison.OrdinalIgnoreCase))
            {
                using Stream stream = entry.Open();
                Bitmap bitmap = BitmapLoading.StreamToBitmap(stream);
                asset.Bitmap = bitmap;
                asset.Filename = Path.GetFileNameWithoutExtension(name);
                asset.AssetPart = Convert.StringToEnum<AssetParts>(asset.Filename);

                pack.Assets.Add(asset);
            }
        }

        return pack;
    }

    public static Workspace LoadWorkspaceFromPaths(Paths paths)
    {
        Pack rootGraphics = LoadPackFromDirectory(paths.RootGraphicsDir);

        rootGraphics = LoadPackFromZip(@"C:\Users\justin\AppData\Roaming\SubStyle\mods\trenchrep.zip");
        Workspace workspace = new Workspace()
        {
            RootGraphics = rootGraphics,
        };

        workspace.Mods.AddRange(paths.ListMods());

        workspace.Targets.AddRange(paths.ListZones());

        return workspace;
    }
}
