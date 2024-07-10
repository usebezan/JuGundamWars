using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizConst.Grades.Domain;

public class GradeInventory : MasterObservableCollection<Grade>
{
    public GradeInventory()
    {
        AddRange<GradeType>(e => e != GradeType.Unknown, e => new(e));
    }
}
