namespace SubStyle.Models;

using System.Reactive;
using ReactiveUI;

public partial class Workspace : ReactiveObject
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
}

/// <summary>
/// Commands.
/// </summary>
public partial class Workspace : ReactiveObject
{
    private ReactiveCommand<Unit, Unit>? applyModCommand;

    private ReactiveCommand<Unit, Unit>? deleteScopeCommand;

    public ReactiveCommand<Unit, Unit> ApplyModCommand => this.applyModCommand ??= ReactiveCommand.Create(this.DoApplyMod, this.CanApplyMod());

    public ReactiveCommand<Unit, Unit> DeleteSelectedScopeItemsCommand => this.deleteScopeCommand ??= ReactiveCommand.Create(this.DoDeleteSelectedScopeItems, this.CanDeleteSelectedScopeItems());

    private IObservable<bool> CanApplyMod()
    {
        return this.WhenAnyValue(
                x => x.ScopePackChoice.SelectedPack,
                x => x.ModPackChoice.SelectedPack!.SelectedAssets.Count,
                (selectedScopePack, numSelectedAssetsFromModPack) => (numSelectedAssetsFromModPack > 0) && (selectedScopePack != null));
    }

    private void DoApplyMod()
    {
        System.Diagnostics.Debug.WriteLine("Running DoApplyMod...");
        if (this.ModPackChoice.SelectedPack == null)
        {
            return;
        }

        var assetsToCopy = this.ModPackChoice.SelectedPack.SelectedAssets;

        this.ScopePackChoice.Overwrite(assetsToCopy);
    }

    private IObservable<bool> CanDeleteSelectedScopeItems()
    {
        return this.WhenAnyValue(
                x => x.ScopePackChoice.SelectedPack!.SelectedAssets.Count,
                x => x > 0);
    }

    private void DoDeleteSelectedScopeItems()
    {
        System.Diagnostics.Debug.WriteLine("Running DoDeleteScope...");
        throw new NotImplementedException();
    }
}
