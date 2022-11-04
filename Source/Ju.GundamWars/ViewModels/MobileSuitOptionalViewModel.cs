using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;


namespace Ju.GundamWars.ViewModels
{

    public class MobileSuitOptionalViewModel : OptionalViewModelBase
    {

        public MobileSuitOptionalViewModel(PilotModelRepository pilotModelRepository, SupportModelRepository supportModelRepository, SerialRepository serialRepository, MiscRepository miscRepository, WindowService windowService)
            : base(serialRepository, windowService)
        {
            OptionalRoles = miscRepository.MobileSuitRoles;
            OptionalInitialGrades = miscRepository.Grades.Where(e => e.Value <= 6).ToList();
            OptionalGrades = miscRepository.Grades;
            OptionalTags = miscRepository.MobileSuitTags;
            OptionalPilots = pilotModelRepository.Models;
            OptionalSupports = supportModelRepository.Models;
        }


        public List<ByteType<MobileSuitRoleType>> OptionalRoles { get; }
        public List<GradeType> OptionalInitialGrades { get; }
        public List<GradeType> OptionalGrades { get; }
        public List<ByteType<MobileSuitTagType>> OptionalTags { get; }
        public ReadOnlyReactiveCollection<PilotModel> OptionalPilots { get; }
        public ReadOnlyReactiveCollection<SupportModel> OptionalSupports { get; }

    }

}
