namespace SubStyle.Models;

using Avalonia.Media.Imaging;
using ReactiveUI;
using SubStyle.Models.Utils;

public class Asset : ReactiveObject
{
    public Bitmap? Bitmap { get; set; }

    public AssetParts? AssetPart { get; set; }

    public string? Filename { get; set; } = "unset";

    public static Asset PathToAsset(string path)
    {
        return new Asset().InitFromPath(path);
    }

    public Asset InitFromPath(string path)
    {
        string assetPath = Path.GetFileNameWithoutExtension(path);

        this.Bitmap = Convert.PathToBitmap(path);
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
