namespace SubStyle.Services;

using System.IO;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1024:Use properties where appropriate")]
public class Paths
{
    public Paths()
    {
        this.InstallDir = @"C:\Program Files (x86)\Continuum";

        this.DataDir = @"C:\Users\justin\AppData\Local\VirtualStore\Program Files (x86)\Continuum";

        this.DefaultGraphicsDir = Path.Join(this.InstallDir, "graphics");

        this.ZonesDir = Path.Join(this.DataDir, "zones");
    }

    public string InstallDir { get; set; }

    public string DataDir { get; set; }

    public string DefaultGraphicsDir { get; set; }

    public string ZonesDir { get; set; }

    public string GetZoneDir(string zone)
    {
        return Path.Combine(this.ZonesDir, zone);
    }

    public string[] ListZones()
    {
        return Directory.GetDirectories(this.ZonesDir)
            .ToList()
            .Select(x => new DirectoryInfo(x).Name)
            .ToArray();
    }
}
