using System;


namespace Ju.GundamWars.Models.Entities
{

    public class Support : BindableBase, IEntity
    {

        public Support()
        {
            Unit = 1;
            Grade = 1;
            Tag = 0;
        }


        public long Id { get => __Id; set => TrySetValue(ref __Id, value); }
        private long __Id;
        public string Name { get => __Name; set => TrySetValue(ref __Name, value); }
        private string __Name = null!;
        public byte Unit { get => __Unit; set => TrySetValue(ref __Unit, value); }
        private byte __Unit;
        public long SerialId { get => __SerialId; set => TrySetValue(ref __SerialId, value); }
        private long __SerialId;
        public long? LimitedSerial1Id { get => __LimitedSerial1Id; set => TrySetValue(ref __LimitedSerial1Id, value); }
        private long? __LimitedSerial1Id;
        public long? LimitedSerial2Id { get => __LimitedSerial2Id; set => TrySetValue(ref __LimitedSerial2Id, value); }
        private long? __LimitedSerial2Id;
        public long? LimitedSerial3Id { get => __LimitedSerial3Id; set => TrySetValue(ref __LimitedSerial3Id, value); }
        private long? __LimitedSerial3Id;
        public long? LimitedSerial4Id { get => __LimitedSerial4Id; set => TrySetValue(ref __LimitedSerial4Id, value); }
        private long? __LimitedSerial4Id;
        public long? LimitedSerial5Id { get => __LimitedSerial5Id; set => TrySetValue(ref __LimitedSerial5Id, value); }
        private long? __LimitedSerial5Id;
        public long? LimitedSerial6Id { get => __LimitedSerial6Id; set => TrySetValue(ref __LimitedSerial6Id, value); }
        private long? __LimitedSerial6Id;
        public byte Grade { get => __Grade; set => TrySetValue(ref __Grade, value); }
        private byte __Grade;

        public long? Slot1Id { get => __Slot1Id; set => TrySetValue(ref __Slot1Id, value); }
        private long? __Slot1Id;
        public long? Badge1Id { get => __Badge1Id; set => TrySetValue(ref __Badge1Id, value); }
        private long? __Badge1Id;
        public long? Slot2Id { get => __Slot2Id; set => TrySetValue(ref __Slot2Id, value); }
        private long? __Slot2Id;
        public long? Badge2Id { get => __Badge2Id; set => TrySetValue(ref __Badge2Id, value); }
        private long? __Badge2Id;
        public long? Slot3Id { get => __Slot3Id; set => TrySetValue(ref __Slot3Id, value); }
        private long? __Slot3Id;
        public long? Badge3Id { get => __Badge3Id; set => TrySetValue(ref __Badge3Id, value); }
        private long? __Badge3Id;
        public long? Slot4Id { get => __Slot4Id; set => TrySetValue(ref __Slot4Id, value); }
        private long? __Slot4Id;
        public long? Badge4Id { get => __Badge4Id; set => TrySetValue(ref __Badge4Id, value); }
        private long? __Badge4Id;
        public long? Slot5Id { get => __Slot5Id; set => TrySetValue(ref __Slot5Id, value); }
        private long? __Slot5Id;
        public long? Badge5Id { get => __Badge5Id; set => TrySetValue(ref __Badge5Id, value); }
        private long? __Badge5Id;
        public long? Slot6Id { get => __Slot6Id; set => TrySetValue(ref __Slot6Id, value); }
        private long? __Slot6Id;
        public long? Badge6Id { get => __Badge6Id; set => TrySetValue(ref __Badge6Id, value); }
        private long? __Badge6Id;
        public long? Slot7Id { get => __Slot7Id; set => TrySetValue(ref __Slot7Id, value); }
        private long? __Slot7Id;
        public long? Badge7Id { get => __Badge7Id; set => TrySetValue(ref __Badge7Id, value); }
        private long? __Badge7Id;
        public long? Slot8Id { get => __Slot8Id; set => TrySetValue(ref __Slot8Id, value); }
        private long? __Slot8Id;
        public long? Badge8Id { get => __Badge8Id; set => TrySetValue(ref __Badge8Id, value); }
        private long? __Badge8Id;
        public long? Slot9Id { get => __Slot9Id; set => TrySetValue(ref __Slot9Id, value); }
        private long? __Slot9Id;
        public long? Badge9Id { get => __Badge9Id; set => TrySetValue(ref __Badge9Id, value); }
        private long? __Badge9Id;
        public long? Slot10Id { get => __Slot10Id; set => TrySetValue(ref __Slot10Id, value); }
        private long? __Slot10Id;
        public long? Badge10Id { get => __Badge10Id; set => TrySetValue(ref __Badge10Id, value); }
        private long? __Badge10Id;
        public long? Slot11Id { get => __Slot11Id; set => TrySetValue(ref __Slot11Id, value); }
        private long? __Slot11Id;
        public long? Badge11Id { get => __Badge11Id; set => TrySetValue(ref __Badge11Id, value); }
        private long? __Badge11Id;
        public long? Slot12Id { get => __Slot12Id; set => TrySetValue(ref __Slot12Id, value); }
        private long? __Slot12Id;
        public long? Badge12Id { get => __Badge12Id; set => TrySetValue(ref __Badge12Id, value); }
        private long? __Badge12Id;
        public byte Tag { get => __Tag; set => TrySetValue(ref __Tag, value); }
        private byte __Tag;
        public string? Memo { get => __Memo; set => TrySetValue(ref __Memo, value); }
        private string? __Memo;

        // define navigation properties:
        public Serial? Serial { get => __Serial; set => TrySetValue(ref __Serial, value); }
        private Serial? __Serial;
        public Serial? LimitedSerial1 { get => __LimitedSerial1; set => TrySetValue(ref __LimitedSerial1, value); }
        private Serial? __LimitedSerial1;
        public Serial? LimitedSerial2 { get => __LimitedSerial2; set => TrySetValue(ref __LimitedSerial2, value); }
        private Serial? __LimitedSerial2;
        public Serial? LimitedSerial3 { get => __LimitedSerial3; set => TrySetValue(ref __LimitedSerial3, value); }
        private Serial? __LimitedSerial3;
        public Serial? LimitedSerial4 { get => __LimitedSerial4; set => TrySetValue(ref __LimitedSerial4, value); }
        private Serial? __LimitedSerial4;
        public Serial? LimitedSerial5 { get => __LimitedSerial5; set => TrySetValue(ref __LimitedSerial5, value); }
        private Serial? __LimitedSerial5;
        public Serial? LimitedSerial6 { get => __LimitedSerial6; set => TrySetValue(ref __LimitedSerial6, value); }
        private Serial? __LimitedSerial6;

        public SupportSlot? Slot1 { get => __Slot1; set => TrySetValue(ref __Slot1, value); }
        private SupportSlot? __Slot1;
        public SupportBadge? Badge1 { get => __Badge1; set => TrySetValue(ref __Badge1, value); }
        private SupportBadge? __Badge1;
        public SupportSlot? Slot2 { get => __Slot2; set => TrySetValue(ref __Slot2, value); }
        private SupportSlot? __Slot2;
        public SupportBadge? Badge2 { get => __Badge2; set => TrySetValue(ref __Badge2, value); }
        private SupportBadge? __Badge2;
        public SupportSlot? Slot3 { get => __Slot3; set => TrySetValue(ref __Slot3, value); }
        private SupportSlot? __Slot3;
        public SupportBadge? Badge3 { get => __Badge3; set => TrySetValue(ref __Badge3, value); }
        private SupportBadge? __Badge3;
        public SupportSlot? Slot4 { get => __Slot4; set => TrySetValue(ref __Slot4, value); }
        private SupportSlot? __Slot4;
        public SupportBadge? Badge4 { get => __Badge4; set => TrySetValue(ref __Badge4, value); }
        private SupportBadge? __Badge4;
        public SupportSlot? Slot5 { get => __Slot5; set => TrySetValue(ref __Slot5, value); }
        private SupportSlot? __Slot5;
        public SupportBadge? Badge5 { get => __Badge5; set => TrySetValue(ref __Badge5, value); }
        private SupportBadge? __Badge5;
        public SupportSlot? Slot6 { get => __Slot6; set => TrySetValue(ref __Slot6, value); }
        private SupportSlot? __Slot6;
        public SupportBadge? Badge6 { get => __Badge6; set => TrySetValue(ref __Badge6, value); }
        private SupportBadge? __Badge6;
        public SupportSlot? Slot7 { get => __Slot7; set => TrySetValue(ref __Slot7, value); }
        private SupportSlot? __Slot7;
        public SupportBadge? Badge7 { get => __Badge7; set => TrySetValue(ref __Badge7, value); }
        private SupportBadge? __Badge7;
        public SupportSlot? Slot8 { get => __Slot8; set => TrySetValue(ref __Slot8, value); }
        private SupportSlot? __Slot8;
        public SupportBadge? Badge8 { get => __Badge8; set => TrySetValue(ref __Badge8, value); }
        private SupportBadge? __Badge8;
        public SupportSlot? Slot9 { get => __Slot9; set => TrySetValue(ref __Slot9, value); }
        private SupportSlot? __Slot9;
        public SupportBadge? Badge9 { get => __Badge9; set => TrySetValue(ref __Badge9, value); }
        private SupportBadge? __Badge9;
        public SupportSlot? Slot10 { get => __Slot10; set => TrySetValue(ref __Slot10, value); }
        private SupportSlot? __Slot10;
        public SupportBadge? Badge10 { get => __Badge10; set => TrySetValue(ref __Badge10, value); }
        private SupportBadge? __Badge10;
        public SupportSlot? Slot11 { get => __Slot11; set => TrySetValue(ref __Slot11, value); }
        private SupportSlot? __Slot11;
        public SupportBadge? Badge11 { get => __Badge11; set => TrySetValue(ref __Badge11, value); }
        private SupportBadge? __Badge11;
        public SupportSlot? Slot12 { get => __Slot12; set => TrySetValue(ref __Slot12, value); }
        private SupportSlot? __Slot12;
        public SupportBadge? Badge12 { get => __Badge12; set => TrySetValue(ref __Badge12, value); }
        private SupportBadge? __Badge12;

    }

}
