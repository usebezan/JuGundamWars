using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public abstract class SelectAllInteractorBase<TOut>(ISelectAllGateway<TOut> gateway, ISelectAllPresenter<TOut>? presenter, ILogger logger)
    : IGw, ISelectAllUseCase<TOut>
    where TOut : class
{
    protected ISelectAllPresenter<TOut>? Presenter { get; } = presenter;
    protected ILogger Logger { get; } = logger;
    public Task<List<TOut>> HandleAsync() =>
        this.Execute(Logger, async () =>
        {
            Presenter?.ShowProgress();
            try
            {
                var items = await gateway.SelectAllAsync();
                Presenter?.Complete(items);
                return items;
            }
            finally
            {
                Presenter?.CloseProgress();
            }
        });
}
