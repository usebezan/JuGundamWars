using Ju.GundamWars.Const;
using Ju.GundamWars.Core.Ju.GundamWars.Cuspas;
using Ju.GundamWars.Cuspas.Domain.Entities;
using Ju.GundamWars.Cuspas.Domain.Factories;
using Ju.GundamWars.Domain.Systems;

namespace Ju.GundamWars.Cuspas;

public class CuspaListController(CuspaEntryViewModel viewModel, CuspaFactory entityFactory, CuspaSubjectFactory subjectFactory, WindowStatus windowStatus)
    : ListControllerBase<Cuspa, CuspaSubject, CuspaEntryViewModel, CuspaFactory, CuspaSubjectFactory>(viewModel, entityFactory, subjectFactory)
{

    protected override void MoveToEntry() => windowStatus.SlideIndexType = SlideIndexType.CuspaEntry;

}
