namespace SubStyle.Models.Utils;

using System;
using System.IO;
using Avalonia.Media.Imaging;
using SubStyle.Sys;

public static class Convert
{
    public static T StringToEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

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
