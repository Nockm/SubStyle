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

        // Dream up mod selection
        {
            Pack? selectedPack = this.ModPackChoice.Items.First(x => x.Assets.Count > 6);

            if (selectedPack == null)
            {
                return;
            }

            selectedPack.SelectedAssets.SetRange(
                new List<Asset>()
                {
                selectedPack.Assets[2],
                selectedPack.Assets[4],
                selectedPack.Assets[5],
                });

            this.ModPackChoice.SelectedPack = selectedPack;
        }

        // Dream up scope selection
        {
            Pack? selectedPack = this.ScopePackChoice.Items.First(x => x.Assets.Count > 6);

            if (selectedPack == null)
            {
                return;
            }

            selectedPack.SelectedAssets.SetRange(
                new List<Asset>()
                {
                selectedPack.Assets[1],
                selectedPack.Assets[3],
                selectedPack.Assets[5],
                });

            this.ScopePackChoice.SelectedPack = selectedPack;
        }
    }
}

public class PackChoiceDtd : PackChoice
{
    public PackChoiceDtd()
    {
        PackChoice packChoice = Dtd.Workspace.ModPackChoice;

        this.Items.SetRange(packChoice.Items);
        this.SelectedPack = packChoice.Items[0];
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
