using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Grades.Domain;

namespace Ju.GundamWars.Client.Grades.Domain;

public class GradeInventory : MasterInventory<Grade>
{
    public GradeInventory()
    {
        AddRange<GradeType>(e => e != GradeType.Unknown, e => new(e));
    }
}
