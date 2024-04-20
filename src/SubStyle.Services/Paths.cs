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
    }

    public string InstallDir { get; set; }

    public string DataDir { get; set; }

    public string DefaultGraphicsDir { get; set; }
}
