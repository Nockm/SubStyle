namespace SubStyle.Views.Dtds;
using System.Linq;
using SubStyle.Models;
using SubStyle.Services;

public static class Dtd
{
    public static Workspace Workspace { get; } = Loading.LoadWorkspace();

    public static Pack? Pack { get; } = Workspace.RootPack;

    public static Asset? Asset { get; } = Pack?.Assets.FirstOrDefault();
}

public class WorkspaceDtd : Workspace
{
    public WorkspaceDtd()
    {
        this.CopyFrom(Dtd.Workspace);
    }
}

public class PackDtd : Pack
{
    public PackDtd()
    {
        this.CopyFrom(Dtd.Pack);
    }
}

public class AssetDtd : Asset
{
    public AssetDtd()
    {
        this.CopyFrom(Dtd.Asset);
    }
}
