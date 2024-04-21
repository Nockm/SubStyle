namespace SubStyle.Sys;

using System;

public static class Convert
{
    public static T StringToEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }
}
