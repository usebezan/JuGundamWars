using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Ju.GundamWars.Commons.Application;

public abstract class PresentableInteractorBase<TIn, TOut, TPresenter>(TPresenter presenter, ISanitizer<TIn>? sanitizer, IValidator<TIn>? validator, ILogger logger) : IGw
    where TPresenter : IPresenter<TOut>
{

    protected TPresenter Presenter { get; } = presenter;
    protected ISanitizer<TIn>? Sanitizer { get; } = sanitizer;
    protected IValidator<TIn>? Validator { get; } = validator;
    protected ILogger Logger { get; } = logger;


    protected Task<TOut> HandleAsync(TIn input, Func<TIn, Task<TOut>> asyncExecutor) =>
        this.Execute(Logger, async () =>
        {
            Presenter.Initialize();

            if (Sanitizer != null)
            {
                input = Sanitizer.Sanitize(input);
            }

            if (Validator != null)
            {
                try
                {
                    Validator.Validate(input);
                }
                catch (ValidationException ex)
                {
                    var message = ex.Message;
                    Logger.LogError("{message}", message);
                    Presenter.ValidationError(ex.Message);
                    throw;
                }
            }

            if (Presenter is IDialogicalPresenter dialogicalPresenter)
            {
                var answer = await dialogicalPresenter.ShowMessageAsync(MessageAnswer.OkCancel);
                if (answer != MessageAnswer.Ok)
                {
                    Logger.LogInformation("Processing was interrupted by the user.");
                    Presenter.Cancel();
                    return default!;
                }
            }

            var progressivePresenter = Presenter as IProgressivePresenter;
            progressivePresenter?.ShowProgress();
            try
            {
                var output = await asyncExecutor(input);
                Presenter.Complete(output);
                return output;
            }
            finally
            {
                progressivePresenter?.CloseProgress();
            }
        });

}
