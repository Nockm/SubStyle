namespace SubStyle.Models;

using System.Collections.ObjectModel;
using ReactiveUI;
using SubStyle.Models.Utils;

public class Pack : ReactiveObject
{
    public string Name { get; set; } = "unset";

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
