using Ju.GundamWars.BizMaster.Grades.Domain.Model;
using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.Grades.Domain.Inventory;

public class GradeInventory : MasterObservableCollection<Grade>
{
    public GradeInventory()
    {
        AddRange<GradeType>(e => e != GradeType.Unknown, e => new(e));
    }
}
