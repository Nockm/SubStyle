namespace SubStyle.Models.Utils;

using System;
using Avalonia.Media.Imaging;

public static class Convert
{
    public static T StringToEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    public static Bitmap PathToBitmap(string path)
    {
        using var assetFileStream = File.OpenRead(path);
        return Bitmap.DecodeToWidth(assetFileStream, 30);
    }
}
