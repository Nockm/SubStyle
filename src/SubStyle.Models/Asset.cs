namespace SubStyle.Models;

using System.Diagnostics;
using System.IO.Compression;
using Avalonia.Media.Imaging;
using ReactiveUI;
using SubStyle.Sys;

public class Asset : ReactiveObject
{
    private Bitmap? bitmap;

    private AssetParts? assetPart;

    private string filename = "filename unset";

    private string? fullpath;

    private string description = "description unset";

    private bool picked;

    public Bitmap? Bitmap
    {
        get => this.bitmap;
        set => this.RaiseAndSetIfChanged(ref this.bitmap, value);
    }

    public AssetParts? AssetPart
    {
        get => this.assetPart;
        set => this.RaiseAndSetIfChanged(ref this.assetPart, value);
    }

    public string Filename
    {
        get => this.filename;
        set => this.RaiseAndSetIfChanged(ref this.filename, value);
    }

    public string? FullPath
    {
        get => this.fullpath;
        set => this.RaiseAndSetIfChanged(ref this.fullpath, value);
    }

    public string Description
    {
        get => this.description;
        set => this.RaiseAndSetIfChanged(ref this.description, value);
    }

    public bool Picked
    {
        get => this.picked;
        set => this.RaiseAndSetIfChanged(ref this.picked, value);
    }

    public static void ValidateBitmap(Bitmap bitmap)
    {
        Trace.Assert(bitmap.PixelSize.Width == bitmap.Size.Width);
        Trace.Assert(bitmap.PixelSize.Height == bitmap.Size.Height);
    }

    public static Asset ZipArchiveEntryToAsset(ZipArchiveEntry entry)
    {
        using var entryStream = entry.Open();

        using var memoryStream = new MemoryStream();
        entryStream.CopyTo(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);

        Asset asset = new Asset();
        asset.Bitmap = new Bitmap(memoryStream);
        asset.Filename = Path.GetFileNameWithoutExtension(entry.Name);
        asset.AssetPart = Convert.StringToEnum<AssetParts>(asset.Filename);

        ValidateBitmap(asset.Bitmap);

        return asset;
    }

    public static Asset PathToAsset(string path)
    {
        return new Asset().InitFromPath(path);
    }

    public Asset InitFromPath(string path)
    {
        string assetPath = Path.GetFileNameWithoutExtension(path);

        this.Bitmap = new Bitmap(path);
        this.Description = string.Empty;
        this.Filename = Path.GetFileNameWithoutExtension(path);
        this.AssetPart = GetAssetPart(assetPath);

        ValidateBitmap(this.Bitmap);

        return this;
    }

    public void CopyFrom(Asset? asset)
    {
        if (asset == null)
        {
            return;
        }

        this.AssetPart = asset.AssetPart;
        this.Bitmap = asset.Bitmap;
        this.Filename = asset.Filename;
    }

    public void SaveTo(string path)
    {
        if (this.Bitmap == null)
        {
            return;
        }

        this.Bitmap.Save(path);
    }

    private static AssetParts GetAssetPart(string assetPath)
    {
        try
        {
            return Convert.StringToEnum<AssetParts>(assetPath);
        }
        catch (ArgumentException)
        {
            return AssetParts.UNKNOWN;
        }
    }
}
