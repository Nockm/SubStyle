namespace SubStyle.Models;

using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using SubStyle.Sys;

public class PackChoice : ReactiveObject
{
    private Pack? selectedItem;

    private ObservableCollection<Pack> packs = new ObservableCollection<Pack>();

    public Pack? SelectedItem
    {
        get => this.selectedItem;
        set => this.RaiseAndSetIfChanged(ref this.selectedItem, value);
    }

    public ObservableCollection<Pack> Items
    {
        get => this.packs;
    }

    public void CopyFrom(PackChoice packChoice)
    {
        this.SelectedItem = packChoice.SelectedItem;
        this.Items.SetRange(packChoice.Items);
    }

    internal void Overwrite(ObservableCollection<Asset> assetsToCopy)
    {
        throw new NotImplementedException();
    }
}
