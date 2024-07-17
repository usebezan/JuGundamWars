using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizConst.Grades.Domain;

public class GradeInventory : MasterInventory<Grade>
{
    public GradeInventory()
    {
        AddRange<GradeType>(e => e != GradeType.Unknown, e => new(e));
    }
}
