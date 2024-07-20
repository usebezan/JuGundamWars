using Ju.GundamWars.Domain;
using Ju.GundamWars.UseCase;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Windows.Data;

namespace Ju.GundamWars;

public static class AppExtension
{

    public static IServiceCollection AddInventory<TService, TImpl>(this IServiceCollection self)
        where TService : class, IInventory
        where TImpl : class, TService, new()
    {
        return self.AddSingleton<TService>(sp =>
        {
            var inventory = new TImpl();
            BindingOperations.EnableCollectionSynchronization(inventory, inventory.LockObj);
            return inventory;
        });
    }

    public static void ChechAll<T>(this ListCollectionView self, bool isChecked)
        where T : SubjectBase
    {
        foreach (var item in self.OfType<T>().ToList())
        {
            item.IsChecked = isChecked;
        }
    }

}
