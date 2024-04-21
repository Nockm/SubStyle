namespace SubStyle.Sys;

using System.Collections.ObjectModel;

public static class ObservableCollectionExtension
{
    public static void AddRange<T>(this ObservableCollection<T> items, IEnumerable<T> collection)
    {
        collection.ToList().ForEach(item => items.Add(item));
    }

    public static void SetRange<T>(this ObservableCollection<T> items, IEnumerable<T> collection)
    {
        items.Clear();
        items.AddRange(collection);
    }
}
