using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive.Linq;


namespace Ju.GundamWars.ViewModels
{

    public class SupportEntryViewModel : EntryViewModelBase<SupportModel, SupportOptionalViewModel>
    {

        public SupportEntryViewModel(EntryType type, SupportModel model, SupportOptionalViewModel optionalViewModel, WindowService windowService)
            : base(type, model, optionalViewModel, windowService)
        {
            Name = Model.Entity.ToReactivePropertyAsSynchronized(e => e.Name).AddTo(Disposables);
            Unit = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Unit).AddTo(Disposables);
            Grade = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Grade).AddTo(Disposables);
            Tag = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Tag).AddTo(Disposables);
            Memo = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Memo).AddTo(Disposables);

            Serial = Model.ToReactivePropertyAsSynchronized(e => e.Serial).AddTo(Disposables);
            LimitedSerials = Model.LimitedSerials;
            SlotBadges = Model.SlotBadges;

            EnhancementsSummary = Model.EnhancementsSummary;

            HasErrors = new[]
                {
                    Name.SetValidateAttribute(() => Name).ObserveHasErrors,
                    Serial.SetValidateAttribute(() => Serial).ObserveHasErrors,
                }
                .CombineLatestValuesAreAllFalse()
                .Select(v => !v)
                .ToReadOnlyReactivePropertySlim()
                .AddTo(Disposables);

            DetachAllBadgesCommand = new ReactiveCommand().WithSubscribe(Model.DetachAllBadges).AddTo(Disposables);
        }


        public override string Title => Type switch
        {
            EntryType.Add => "Support Add",
            EntryType.Edit => "Support Edit",
            EntryType.Copy => "Support Copy",
            _ => "Support Entry",
        };
        public override string IconKind => "FaceAgent";

        [Required(ErrorMessage = "Required.")]
        public ReactiveProperty<string> Name { get; }
        public ReactivePropertySlim<byte> Unit { get; }
        public ReactivePropertySlim<byte> Grade { get; }
        public ReactivePropertySlim<byte> Tag { get; }
        public ReactivePropertySlim<string?> Memo { get; }

        [Required(ErrorMessage = "Required.")]
        public ReactiveProperty<Serial?> Serial { get; }
        public List<Wrapper<Serial?>> LimitedSerials { get; }
        public List<Wrapper<SupportSlot?, SupportBadge?>> SlotBadges { get; }

        public ObservableCollection<KeyValuePair<string, string>> EnhancementsSummary { get; }

        public override ReadOnlyReactivePropertySlim<bool> HasErrors { get; }

        public ReactiveCommand DetachAllBadgesCommand { get; }

    }

}
