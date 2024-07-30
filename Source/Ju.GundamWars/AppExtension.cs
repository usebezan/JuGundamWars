using Ju.GundamWars.Client.Commons.Domain;
using System.Windows.Data;

namespace Ju.GundamWars;

public static class AppExtension
{

    public static void CheckAll<T>(this ListCollectionView self)
        where T : BizBase
    {
        foreach (var item in self.OfType<T>().ToList())
        {
            item.IsChecked = true;
        }
    }

    public static void UncheckAll<T>(this ListCollectionView self)
        where T : BizBase
    {
        foreach (var item in self.OfType<T>().ToList())
        {
            item.IsChecked = false;
        }
    }

}
