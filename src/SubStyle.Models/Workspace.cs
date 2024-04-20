namespace SubStyle.Models;

using System.Collections.ObjectModel;
using ReactiveUI;

public class Workspace : ReactiveObject
{
    private string? selectedMod;
    private ObservableCollection<string> mods = new ObservableCollection<string>();
    private Pack? selectedModGraphics;
    private string? selectedTarget;
    private ObservableCollection<string> targets = new ObservableCollection<string>();
    private Pack? selectedTargetGraphics;
    private Pack? rootGraphics;
    private Pack? previewGraphics;

    public string? SelectedMod
    {
        get => this.selectedMod;
        set => this.RaiseAndSetIfChanged(ref this.selectedMod, value);
    }

    public ObservableCollection<string> Mods
    {
        get => this.mods;
    }

    public Pack? SelectedModGraphics
    {
        get => this.selectedModGraphics;
        set => this.RaiseAndSetIfChanged(ref this.selectedModGraphics, value);
    }

    public string? SelectedTarget
    {
        get => this.selectedTarget;
        set => this.RaiseAndSetIfChanged(ref this.selectedTarget, value);
    }

    public ObservableCollection<string> Targets
    {
        get => this.targets;
    }

    public Pack? SelectedTargetGraphics
    {
        get => this.selectedTargetGraphics;
        set => this.RaiseAndSetIfChanged(ref this.selectedTargetGraphics, value);
    }

    public Pack? RootGraphics
    {
        get => this.rootGraphics;
        set => this.RaiseAndSetIfChanged(ref this.rootGraphics, value);
    }

    /// <summary>
    /// Gets or sets the graphics that would result from overlaying RootGraphics -> SelectedTargetGraphics -> SelectedModGraphics.
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
