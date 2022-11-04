using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Data;


namespace Ju.GundamWars.ViewModels
{

    public class PilotOptionalViewModel : OptionalViewModelBase
    {

        public PilotOptionalViewModel(PilotSkillRepository pilotSkillRepository, PilotAbilityRepository pilotAbilityRepository, SerialRepository serialRepository, MiscRepository miscRepository, WindowService windowService)
            : base(serialRepository, windowService)
        {
            OptionalUnits = miscRepository.Units.Where(e => e.Type == UnitType.MobileSuit || e.Type == UnitType.MobileArmor).ToList();
            OptionalGrades = miscRepository.Grades.Where(e => e.Value <= 6).ToList();
            OptionalTags = miscRepository.PilotTags;
            OptionalSkills = pilotSkillRepository.Entities;
            OptionalSlotRanks = miscRepository.PilotSlotRanks;
            OptionalAbilities = new(pilotAbilityRepository.Entities);
            OptionalAbilities.GroupDescriptions.Add(new PropertyGroupDescription("TargetTypeText"));
        }


        public List<ByteType<UnitType>> OptionalUnits { get; }
        public List<GradeType> OptionalGrades { get; }
        public List<ByteType<PilotTagType>> OptionalTags { get; }
        public ObservableCollection<PilotSkill> OptionalSkills { get; }
        public List<byte> OptionalSlotRanks { get; }
        public ListCollectionView OptionalAbilities { get; }

    }

}
