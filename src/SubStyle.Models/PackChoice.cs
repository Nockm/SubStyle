namespace SubStyle.Models;

using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using SubStyle.Sys;

public class PackChoice : ReactiveObject
{
    private Pack? selectedPack;

    private ObservableCollection<Pack> packs = new ObservableCollection<Pack>();

    public Pack? SelectedPack
    {
        get => this.selectedPack;
        set => this.RaiseAndSetIfChanged(ref this.selectedPack, value);
    }

    public ObservableCollection<Pack> Items
    {
        get => this.packs;
    }

    public void CopyFrom(PackChoice packChoice)
    {
        this.SelectedPack = packChoice.SelectedPack;
        this.Items.SetRange(packChoice.Items);
    }

    internal void Overwrite(ObservableCollection<Asset> assetsToCopy)
    {
        throw new NotImplementedException();
    }
}
