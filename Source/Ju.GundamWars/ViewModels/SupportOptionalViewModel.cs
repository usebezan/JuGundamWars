using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Data;


namespace Ju.GundamWars.ViewModels
{

    public class SupportOptionalViewModel : OptionalViewModelBase
    {

        public SupportOptionalViewModel(SupportSlotRepository supportSlotRepository, SupportBadgeRepository supportBadgeRepository, SerialRepository serialRepository, MiscRepository miscRepository, WindowService windowService)
            : base(serialRepository, windowService)
        {
            OptionalUnits = miscRepository.Units.Where(e => e.Type == UnitType.MobileSuit || e.Type == UnitType.MobileArmor).ToList();
            OptionalGrades = miscRepository.Grades.Where(e => e.Value <= 6).ToList();
            OptionalTags = miscRepository.SupportTags;
            OptionalSlots = new ListCollectionView(supportSlotRepository.Entities);
            OptionalSlots.GroupDescriptions.Add(new PropertyGroupDescription("TargetTypeText"));
            OptionalBadges = new ListCollectionView(supportBadgeRepository.Entities);
            OptionalBadges.GroupDescriptions.Add(new PropertyGroupDescription("TargetTypeText"));
        }


        public List<ByteType<UnitType>> OptionalUnits { get; }
        public List<GradeType> OptionalGrades { get; }
        public List<ByteType<SupportTagType>> OptionalTags { get; }
        public ListCollectionView OptionalSlots { get; }
        public ListCollectionView OptionalBadges { get; }

    }

}
