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
        MemoryStream memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);

        memoryStream.Seek(0, SeekOrigin.Begin);
        BitmapInfo bitmapInfo = new BitmapInfo(memoryStream);
        uint width = bitmapInfo.WidthPixels;

        memoryStream.Seek(0, SeekOrigin.Begin);
        Bitmap bitmap = Bitmap.DecodeToWidth(memoryStream, (int)width);

        return bitmap;
    }

    public static string PathToBitmapSummary(string path)
    {
        using FileStream stream = File.OpenRead(path);
        BitmapInfo bitmapInfo = new BitmapInfo(stream);
        return bitmapInfo.ToString();
    }
}
