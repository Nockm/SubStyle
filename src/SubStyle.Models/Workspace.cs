namespace SubStyle.Models;

using ReactiveUI;

public class Workspace : ReactiveObject
{
    private PackChoice modPackChoice = new PackChoice();

    private PackChoice scopePackChoice = new PackChoice();

    private Pack? rootGraphics;

    private Pack? previewGraphics;

    public PackChoice ModPackChoice
    {
        get => this.modPackChoice;
    }

    public PackChoice ScopePackChoice
    {
        get => this.scopePackChoice;
    }

    public Pack? RootGraphics
    {
        get => this.rootGraphics;
        set => this.RaiseAndSetIfChanged(ref this.rootGraphics, value);
    }

    /// <summary>
    /// Gets or sets the graphics that would result from overlaying RootGraphics -> SelectedScope -> SelectedMod.
    /// </summary>
    public Pack? PreviewGraphics
    {
        get => this.previewGraphics;
        set => this.RaiseAndSetIfChanged(ref this.previewGraphics, value);
    }

    public void CopyFrom(Workspace? workspace)
    {
        if (workspace == null)
        {
            return;
        }

        this.RootGraphics?.CopyFrom(workspace.RootGraphics);
        this.PreviewGraphics?.CopyFrom(workspace.PreviewGraphics);
        this.ModPackChoice.CopyFrom(workspace.ModPackChoice);
        this.ScopePackChoice.CopyFrom(workspace.ScopePackChoice);
    }

    public void CopySelectedModItemsToScope()
    {
        if (this.ModPackChoice.SelectedItem == null)
        {
            return;
        }

        var assetsToCopy = this.ModPackChoice.SelectedItem.SelectedAssets;

        this.ScopePackChoice.Overwrite(assetsToCopy);
    }

    public void DeleteSelectedScopeItems()
    {
        throw new NotImplementedException();
    }
}
