namespace SubStyle.Models;

using System.Collections.ObjectModel;
using ReactiveUI;

public class Pack : ReactiveObject
{
    public string Name { get; set; } = "unset";

    public ObservableCollection<Asset> Assets { get; } = new ObservableCollection<Asset>();

    public Pack SetAssets(IList<Asset> assets)
    {
        this.Assets.Clear();
        assets.ToList().ForEach(this.Assets.Add);

        return this;
    }

    public void CopyFrom(Pack? pack)
    {
        if (pack == null)
        {
            return;
        }

        this.SetAssets(pack.Assets);
    }
}
