using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;


namespace Ju.GundamWars.ViewModels
{

    public class SupportFilterViewModel : FilterViewModelBase<SupportDisplayViewModel>
    {

        public SupportFilterViewModel(SupportSlotRepository supportSlotRepository, SupportBadgeRepository supportBadgeRepository, SerialRepository serialRepository, MiscRepository miscRepository, WindowService windowService)
            : base(serialRepository, windowService)
        {
            FilteringUnits = miscRepository.Units.Where(e => e.Type == UnitType.MobileSuit || e.Type == UnitType.MobileArmor).ToList();
            FilteringLimitedSerials = serialRepository.Entities;
            FilteringSlots = supportSlotRepository.Entities.Where(e => e.Target2Type != Target2Type.None && e.Target2Type != Target2Type.Unknown).OrderBy(e => e.Order).GroupBy(e => e.Target2).Select(a => new ByteType<Target2Type>(a.Key.ToTarget2Type(), a.Key, a.Key.ToTarget2Type().ToText())).ToList();
            FilteringBadges = new ListCollectionView(supportBadgeRepository.Entities);
            FilteringTags = miscRepository.SupportTags;

            UnitFilter = new ReactivePropertySlim<ByteType<UnitType>?>().AddTo(Disposables);
            LimitedSerialFilter = new ReactivePropertySlim<Serial?>().AddTo(Disposables);
            SlotFilter = new ReactivePropertySlim<ByteType<Target2Type>?>().AddTo(Disposables);
            FilteringBadges.GroupDescriptions.Add(new PropertyGroupDescription("TargetTypeText"));
            BadgeFilter = new ReactivePropertySlim<SupportBadge?>().AddTo(Disposables);
            TagFilter = new ReactivePropertySlim<ByteType<SupportTagType>?>().AddTo(Disposables);

            UnitFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
            LimitedSerialFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
            SlotFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
            BadgeFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
            TagFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
        }


        protected override bool IsEmpty => base.IsEmpty
            && UnitFilter.Value == null
            && LimitedSerialFilter.Value == null
            && SlotFilter.Value == null
            && BadgeFilter.Value == null
            && TagFilter.Value == null;

        public List<ByteType<UnitType>> FilteringUnits { get; }
        public ObservableCollection<Serial> FilteringLimitedSerials { get; }
        public List<ByteType<Target2Type>> FilteringSlots { get; }
        public ListCollectionView FilteringBadges { get; }
        public List<ByteType<SupportTagType>> FilteringTags { get; }

        public ReactivePropertySlim<ByteType<UnitType>?> UnitFilter { get; }
        public ReactivePropertySlim<Serial?> LimitedSerialFilter { get; }
        public ReactivePropertySlim<ByteType<Target2Type>?> SlotFilter { get; }
        public ReactivePropertySlim<SupportBadge?> BadgeFilter { get; }
        public ReactivePropertySlim<ByteType<SupportTagType>?> TagFilter { get; }


        protected override bool Filter(SupportDisplayViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(WordFilter.Value)
                && !viewModel.Name.Value.Contains(WordFilter.Value)
                && !(viewModel.Memo.Value ?? "").Contains(WordFilter.Value)) return false;
            if (UnitFilter.Value != null
                && UnitFilter.Value.Value != viewModel.Unit.Value) return false;
            if (SerialFilter.Value != null
                && SerialFilter.Value.Id != viewModel.Serial.Value?.Id) return false;
            if (LimitedSerialFilter.Value != null
                && !viewModel.LimitedSerials.Any(w => LimitedSerialFilter.Value.Id == w.Item1?.Id)) return false;
            if (SlotFilter.Value != null
                && !viewModel.SlotBadges.Any(w => SlotFilter.Value.Value == w.Item1?.Target2)) return false;
            if (BadgeFilter.Value != null
                && !viewModel.SlotBadges.Any(e => BadgeFilter.Value.Id == e.Item2?.Id)) return false;
            if (TagFilter.Value != null
                && TagFilter.Value.Value != viewModel.Tag.Value) return false;
            if (HasMemoFilter.Value && !viewModel.HasMemo.Value) return false;
            return true;
        }

        public override void Clear()
        {
            IsReady = false;
            WordFilter.Value = "";
            SerialFilter.Value = null;
            HasMemoFilter.Value = false;
            UnitFilter.Value = null;
            LimitedSerialFilter.Value = null;
            SlotFilter.Value = null;
            BadgeFilter.Value = null;
            TagFilter.Value = null;
            IsReady = true;
            Refilter();
        }

    }

}
