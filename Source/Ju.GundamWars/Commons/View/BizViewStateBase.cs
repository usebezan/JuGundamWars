using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class BizViewStateBase : ModelBase
{

    [ObservableProperty, NotifyPropertyChangedFor(nameof(PageIndex))]
    private PageIndexType _PageIndexType = PageIndexType.List;
    public int PageIndex => PageIndexType.ToValue();

    [ObservableProperty]
    private IDisposable? _EntryContent;


    partial void OnEntryContentChanged(IDisposable? oldValue, IDisposable? newValue)
    {
        oldValue?.Dispose();
    }

}
