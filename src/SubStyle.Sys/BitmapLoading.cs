namespace SubStyle.Sys;

using Avalonia.Media.Imaging;

public static class BitmapLoading
{
    public static Bitmap PathToBitmap(string path)
    {
        using FileStream stream = File.OpenRead(path);
        return StreamToBitmap(stream);
    }

    public static Bitmap StreamToBitmap(Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        BitmapInfo bitmapInfo = new BitmapInfo(stream);
        uint width = bitmapInfo.WidthPixels;

        stream.Seek(0, SeekOrigin.Begin);
        return Bitmap.DecodeToWidth(stream, (int)width);
    }

    public static string PathToBitmapSummary(string path)
    {
        using FileStream stream = File.OpenRead(path);
        BitmapInfo bitmapInfo = new BitmapInfo(stream);
        return bitmapInfo.ToString();
    }
}
