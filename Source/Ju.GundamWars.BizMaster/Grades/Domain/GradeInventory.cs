using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.Grades.Domain;

public class GradeInventory : EnumObservableCollection<Grade>
{
    public GradeInventory()
    {
        AddRange<GradeType>(e => e != GradeType.Unknown, e => new(e));
    }
}
