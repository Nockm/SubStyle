namespace SubStyle.Models;

using System.Collections.ObjectModel;
using ReactiveUI;

public class Workspace : ReactiveObject
{
    private Pack? selectedMod;
    private ObservableCollection<Pack> mods = new ObservableCollection<Pack>();

    private Pack? selectedScope;
    private ObservableCollection<Pack> scopes = new ObservableCollection<Pack>();

    private Pack? rootGraphics;
    private Pack? previewGraphics;

    public Pack? SelectedMod
    {
        get => this.selectedMod;
        set => this.RaiseAndSetIfChanged(ref this.selectedMod, value);
    }

    public ObservableCollection<Pack> Mods
    {
        get => this.mods;
    }

    public Pack? SelectedScope
    {
        get => this.selectedScope;
        set => this.RaiseAndSetIfChanged(ref this.selectedScope, value);
    }

    public ObservableCollection<Pack> Scopes
    {
        get => this.scopes;
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

        this.RootGraphics = workspace.RootGraphics;
    }
}
