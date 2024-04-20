namespace SubStyle.Models;

using ReactiveUI;

public class Workspace : ReactiveObject
{
    public Pack? RootPack { get; set; }

    public void CopyFrom(Workspace? workspace)
    {
        if (workspace == null)
        {
            return;
        }

        this.RootPack = workspace.RootPack;
    }
}
