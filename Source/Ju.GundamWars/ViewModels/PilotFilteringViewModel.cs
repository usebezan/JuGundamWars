using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Ju.GundamWars.ViewModels
{

    public class PilotFilteringViewModel : FilteringViewModelBase<PilotDisplayViewModel>
    {

        public PilotFilteringViewModel(PilotSkillRepository pilotSkillRepository, PilotAbilityRepository pilotAbilityRepository, SerialRepository serialRepository, MiscRepository miscRepository, WindowService windowService)
            : base(serialRepository, windowService)
        {
            FilteringUnits = miscRepository.Units.Where(e => e.Type == UnitType.MobileSuit || e.Type == UnitType.MobileArmor).ToList();
            FilteringSkills = pilotSkillRepository.Entities;
            FilteringAbilities = pilotAbilityRepository.Entities.Where(e => e.Target2Type != Target2Type.None && e.Target2Type != Target2Type.Unknown).OrderBy(e => e.Order).GroupBy(e => e.Target2).Select(a => new ByteType<Target2Type>(a.Key.ToTarget2Type(), a.Key, a.Key.ToTarget2Type().ToText())).ToList();
            FilteringTags = miscRepository.PilotTags;

            UnitFilter = new ReactivePropertySlim<ByteType<UnitType>?>().AddTo(Disposables);
            SkillFilter = new ReactivePropertySlim<PilotSkill?>().AddTo(Disposables);
            AbilityFilter = new ReactivePropertySlim<ByteType<Target2Type>?>().AddTo(Disposables);
            TagFilter = new ReactivePropertySlim<ByteType<PilotTagType>?>().AddTo(Disposables);

            UnitFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
            SkillFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
            AbilityFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
            TagFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
        }


        protected override bool IsEmpty => base.IsEmpty
            && UnitFilter.Value == null
            && SkillFilter.Value == null
            && AbilityFilter.Value == null
            && TagFilter.Value == null;

        public List<ByteType<UnitType>> FilteringUnits { get; }
        public ObservableCollection<PilotSkill> FilteringSkills { get; }
        public List<ByteType<Target2Type>> FilteringAbilities { get; }
        public List<ByteType<PilotTagType>> FilteringTags { get; }

        public ReactivePropertySlim<ByteType<UnitType>?> UnitFilter { get; }
        public ReactivePropertySlim<PilotSkill?> SkillFilter { get; }
        public ReactivePropertySlim<ByteType<Target2Type>?> AbilityFilter { get; }
        public ReactivePropertySlim<ByteType<PilotTagType>?> TagFilter { get; }


        protected override bool Filter(PilotDisplayViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(WordFilter.Value)
                && !viewModel.Name.Value.Contains(WordFilter.Value)
                && !(viewModel.SkillText1.Value ?? "").Contains(WordFilter.Value)
                && !(viewModel.Memo.Value ?? "").Contains(WordFilter.Value)) return false;
            if (UnitFilter.Value != null
                && UnitFilter.Value.Value != viewModel.Unit.Value) return false;
            if (SerialFilter.Value != null
                && SerialFilter.Value.Id != viewModel.Serial.Value?.Id) return false;
            if (SkillFilter.Value != null
                && SkillFilter.Value.Id != viewModel.Skill.Value?.Id) return false;
            if (AbilityFilter.Value != null
                && AbilityFilter.Value.Value != viewModel.Ability1.Value?.Target2
                && AbilityFilter.Value.Value != viewModel.Ability2.Value?.Target2
                && AbilityFilter.Value.Value != viewModel.Ability3.Value?.Target2) return false;
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
            SkillFilter.Value = null;
            AbilityFilter.Value = null;
            TagFilter.Value = null;
            IsReady = true;
            Refilter();
        }

    }

}
