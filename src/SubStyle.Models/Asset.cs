namespace SubStyle.Models;

using Avalonia.Media.Imaging;
using ReactiveUI;
using SubStyle.Sys;

public class Asset : ReactiveObject
{
    private Bitmap? bitmap;

    private AssetParts? assetPart;

    private string filename = "filename unset";

    private string description = "description unset";

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

    public string Description
    {
        get => this.description;
        set => this.RaiseAndSetIfChanged(ref this.description, value);
    }

    public static Asset PathToAsset(string path)
    {
        return new Asset().InitFromPath(path);
    }

    public Asset InitFromPath(string path)
    {
        string assetPath = Path.GetFileNameWithoutExtension(path);

        this.Description = BitmapLoading.PathToBitmapSummary(path);
        this.Bitmap = BitmapLoading.PathToBitmap(path);
        this.Filename = Path.GetFileNameWithoutExtension(path);
        this.AssetPart = Convert.StringToEnum<AssetParts>(assetPath);

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
}
