using System;
using System.Collections.Generic;
using System.Linq;


namespace Ju.GundamWars.Models.Repositories
{

    public class MiscRepository : IRepository
    {

        public MiscRepository()
        {
            Load();
        }


        public List<GradeType> Grades { get; private set; } = null!;
        public List<ByteType<UnitType>> Units { get; private set; } = null!;
        public List<ByteType<Target2Type>> Targets { get; private set; } = null!;
        //public List<IntType<EffectType>> Effects { get; private set; } = null!;
        public List<ByteType<MobileSuitTagType>> MobileSuitTags { get; private set; } = null!;
        public List<ByteType<PilotTagType>> PilotTags { get; private set; } = null!;
        public List<ByteType<SupportTagType>> SupportTags { get; private set; } = null!;
        public List<byte> PilotSlotRanks { get; private set; } = null!;
        public List<ByteType<MobileSuitRoleType>> MobileSuitRoles { get; private set; } = null!;


        public void Load()
        {
            Grades = new()
            {
                new GradeType(1, 1, "Goldenrod"),
                new GradeType(2, 2, "Goldenrod"),
                new GradeType(3, 3, "Goldenrod"),
                new GradeType(4, 4, "Goldenrod"),
                new GradeType(5, 5, "Goldenrod"),
                new GradeType(6, 6, "Goldenrod"),
                new GradeType(7, 1, "MediumPurple"),
                new GradeType(8, 2, "MediumPurple"),
                new GradeType(9, 3, "MediumPurple"),
                new GradeType(10, 4, "MediumPurple"),
                new GradeType(11, 5, "MediumPurple"),
                new GradeType(12, 6, "MediumPurple"),
            };

            Units = Enum.GetValues(typeof(UnitType))
                .OfType<UnitType>()
                .Where(e => e != UnitType.Unknown)
                .Select(e => new ByteType<UnitType>(e, e.ToValue(), e.ToText(), e.ToIconKind()))
                .ToList();

            Targets = Enum.GetValues(typeof(Target2Type))
                .OfType<Target2Type>()
                .Where(e => e != Target2Type.Unknown)
                .Select(e => new ByteType<Target2Type>(e, e.ToValue(), e.ToText()))
                .ToList();

            //Effects = Enum.GetValues(typeof(EffectType))
            //    .OfType<EffectType>()
            //    .Where(e => e != EffectType.Unknown)
            //    .Select(e => new IntType<EffectType>(e, e.ToValue(), e.ToText()))
            //    .ToList();

            MobileSuitTags = Enum.GetValues(typeof(MobileSuitTagType))
                .OfType<MobileSuitTagType>()
                .Select(e => new ByteType<MobileSuitTagType>(e, e.ToValue(), e.ToText(), e.ToIconKind()))
                .ToList();

            PilotTags = Enum.GetValues(typeof(PilotTagType))
                .OfType<PilotTagType>()
                .Select(e => new ByteType<PilotTagType>(e, e.ToValue(), e.ToText(), e.ToIconKind()))
                .ToList();

            SupportTags = Enum.GetValues(typeof(SupportTagType))
                .OfType<SupportTagType>()
                .Select(e => new ByteType<SupportTagType>(e, e.ToValue(), e.ToText(), e.ToIconKind()))
                .ToList();

            PilotSlotRanks = new List<byte>() { 1, 2, 3, 4, 5, };

            MobileSuitRoles = Enum.GetValues(typeof(MobileSuitRoleType))
                .OfType<MobileSuitRoleType>()
                .Where(e => e != MobileSuitRoleType.Unknown)
                .Select(e => new ByteType<MobileSuitRoleType>(e, e.ToValue(), e.ToText()))
                .ToList();
        }

    }

}
