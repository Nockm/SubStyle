namespace SubStyle.Models;

using System.Collections.ObjectModel;
using ReactiveUI;

public class Workspace : ReactiveObject
{
    public Pack? RootPack { get; set; }

    public ObservableCollection<string> Zones { get; } = new ObservableCollection<string>();

    public void CopyFrom(Workspace? workspace)
    {
        if (workspace == null)
        {
            return;
        }

        this.RootPack = workspace.RootPack;
    }
}
