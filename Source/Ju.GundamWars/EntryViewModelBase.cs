using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Const;
using Ju.GundamWars.Core;
using Ju.GundamWars.Core.Common.Domain;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ju.GundamWars;

public abstract partial class EntryViewModelBase<TSubject, TController, TSubjectFactory> : GwObservableObject, IEntryViewModel<TSubject>
    where TSubject : class, IDisposable, ITaggable
    where TController : IEntryController<TSubject>
    where TSubjectFactory : IFactory<TSubject>
{

    public EntryViewModelBase(TController controller, TSubjectFactory subjectFactory, ITagInventory tagInventory)
    {
        Controller = controller;
        SubjectFactory = subjectFactory;
        TagInventory = tagInventory;

        Mode = EntryMode.None;
        Entry = null!;
        Icon = GwIcon.Unknown;
        Text = GwText.Unknown;
    }


    protected TController Controller { get; }
    protected TSubjectFactory SubjectFactory { get; }
    protected ITagInventory TagInventory { get; }

    [ObservableProperty, NotifyPropertyChangedFor(nameof(IsAdd)), NotifyPropertyChangedFor(nameof(IsEdit)), NotifyPropertyChangedFor(nameof(TabIndex))]
    private EntryMode _Mode;
    [ObservableProperty]
    private TSubject _Entry;
    [ObservableProperty]
    private string _Icon;
    [ObservableProperty]
    private string _Text;

    public bool IsAdd => Mode == EntryMode.New || Mode == EntryMode.Copy;
    public bool IsEdit => Mode == EntryMode.Edit;
    public virtual int TabIndex => Mode == EntryMode.New ? 0 : 2;


    public virtual void SetEntry(EntryMode mode, TSubject entry)
    {
        Mode = EntryMode.None;
        Entry = null!;

        Mode = mode;
        Entry = entry;

        foreach (var tag in TagInventory)
        {
            tag.IsChecked = Entry.Tags.Contains(tag);
        }
    }

    [RelayCommand]
    private async Task EnterAsync()
    {
        Entry.ReAddTags(TagInventory.Where(i => i.IsChecked).ToList());
        if (IsAdd)
        {
            await Controller.InsertAsync(Entry);
        }
        else if (IsEdit)
        {
            await Controller.UpdateAsync(Entry);
        }
    }

    [RelayCommand]
    private async Task CancelAsync()
    {
        var isOK = await Controller.CancelAsync(Entry);
        if (isOK && IsAdd)
        {
            Entry.Dispose();
        }
    }

    [RelayCommand]
    private async Task DeleteAsync() => await Controller.DeleteAsync(Entry);

    [RelayCommand]
    private void UncheckAllTags() => TagInventory.UncheckAll();

}
