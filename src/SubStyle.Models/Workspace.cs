namespace SubStyle.Models;

using System.Collections.ObjectModel;
using ReactiveUI;

public class Workspace : ReactiveObject
{
    /// <summary>
    /// Gets or sets the name of the selected mod.
    /// </summary>
    public string? SelectedMod { get; set; }

    /// <summary>
    /// Gets the available mods.
    /// </summary>
    public ObservableCollection<string> Mods { get; } = new ObservableCollection<string>();

    /// <summary>
    /// Gets or sets the graphics in the selected mod.
    /// </summary>
    public Pack? SelectedModGraphics { get; set; }

    /// <summary>
    /// Gets or sets the name of the selected target.
    /// </summary>
    public string? SelectedTarget { get; set; }

    /// <summary>
    /// Gets the available targets.
    /// </summary>
    public ObservableCollection<string> Targets { get; } = new ObservableCollection<string>();

    /// <summary>
    /// Gets or sets the graphics currently at the selected target.
    /// </summary>
    public Pack? SelectedTargetGraphics { get; set; }

    /// <summary>
    /// Gets or sets the graphics currently at the root graphics directory.
    /// </summary>
    public Pack? RootGraphics { get; set; }

    /// <summary>
    /// Gets or sets the graphics that would result from overlaying RootGraphics -> SelectedTargetGraphics -> SelectedModGraphics.
    /// </summary>
    public Pack? PreviewGraphics { get; set; }

    public void CopyFrom(Workspace? workspace)
    {
        if (workspace == null)
        {
            return;
        }

        this.RootGraphics = workspace.RootGraphics;
    }
}
