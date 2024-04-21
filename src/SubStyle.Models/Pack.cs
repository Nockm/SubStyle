namespace SubStyle.Models;

using System.Collections.ObjectModel;
using ReactiveUI;
using SubStyle.Sys;

public class Pack : ReactiveObject
{
    private string name = "name unset";

    private string notes = "notes unset";

    public string Name
    {
        get => this.name;
        set => this.RaiseAndSetIfChanged(ref this.name, value);
    }

    public string Notes
    {
        get => this.notes;
        set => this.RaiseAndSetIfChanged(ref this.notes, value);
    }

    public ObservableCollection<Asset> Assets { get; } = new ObservableCollection<Asset>();

    public void CopyFrom(Pack? pack)
    {
        if (pack == null)
        {
            return;
        }

        this.Assets.SetRange(pack.Assets);
    }
}
