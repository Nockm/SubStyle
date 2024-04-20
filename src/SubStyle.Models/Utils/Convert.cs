namespace SubStyle.Models.Utils;

using System;
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
        AssessBitmap(path);
        using var assetFileStream1 = File.OpenRead(path);
        BitmapInfo bitmapInfo = new BitmapInfo(assetFileStream1);
        uint width = bitmapInfo.WidthPixels;

        using var assetFileStream = File.OpenRead(path);
        return Bitmap.DecodeToWidth(assetFileStream, (int)width);
    }

    public static string AssessBitmap(string path)
    {
        using var assetFileStream = File.OpenRead(path);

        return new BitmapInfo(assetFileStream).ToString();
    }
}
