using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Ju.GundamWars.Commons.Application;

public abstract class InteractorBase<TIn, TOut>(ISanitizer<TIn>? sanitizer, IValidator<TIn>? validator, ILogger logger) : IGw
{

    protected ISanitizer<TIn>? Sanitizer { get; } = sanitizer;
    protected IValidator<TIn>? Validator { get; } = validator;
    protected ILogger Logger { get; } = logger;


    protected Task<TOut> HandleAsync(TIn input, Func<TIn, Task<TOut>> asyncExecutor) =>
        this.Execute(Logger, () =>
        {
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
                    Logger.LogError("{message}", ex.Message);
                    throw;
                }
            }
            return asyncExecutor(input);
        });

}
