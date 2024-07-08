using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Cuspas;
using Ju.GundamWars.Domain.Cuspas.Entities;
using Ju.GundamWars.Domain.Cuspas.Factories;
using Ju.GundamWars.Domain.Systems;

namespace Ju.GundamWars.Cuspas;

public class CuspaListController(CuspaEntryViewModel viewModel, CuspaFactory entityFactory, CuspaSubjectFactory subjectFactory, WindowStatus windowStatus)
    : ListControllerBase<Cuspa, CuspaSubject, CuspaEntryViewModel, CuspaFactory, CuspaSubjectFactory>(viewModel, entityFactory, subjectFactory)
{

    protected override void MoveToEntry() => windowStatus.SlideIndexType = SlideIndexType.CuspaEntry;

}
