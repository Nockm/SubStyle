namespace SubStyle.Views.Dtds;
using System.Linq;
using SubStyle.Models;
using SubStyle.Services;
using SubStyle.Sys;

public static class Dtd
{
    public static Workspace Workspace { get; } = Loading.LoadWorkspace();

    public static PackChoice PackChoice { get; } = Workspace.ModPackChoice;

    public static Pack? Pack { get; } = Workspace.RootGraphics;

    public static Asset? Asset { get; } = Pack?.Assets.FirstOrDefault();
}

public class WorkspaceDtd : Workspace
{
    public WorkspaceDtd()
    {
        this.CopyFrom(Dtd.Workspace);
    }
}

public class PackChoiceDtd : PackChoice
{
    public PackChoiceDtd()
    {
        PackChoice packChoice = Dtd.Workspace.ModPackChoice;

        this.Items.SetRange(packChoice.Items);
        this.SelectedItem = packChoice.Items[0];
    }
}

public class PackDtd : Pack
{
    public PackDtd()
    {
        this.CopyFrom(Dtd.Pack);

        this.Assets[3].Picked = true;
        this.Assets[5].Picked = true;
        this.Assets[6].Picked = true;
    }
}

public class AssetDtd : Asset
{
    public AssetDtd()
    {
        this.CopyFrom(Dtd.Asset);
    }
}
