using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Ju.GundamWars;

public static class CoreExtension
{

    public static void Execute(this IGw _, ILogger logger, Action executor, [CallerMemberName] string? callerMemberName = null)
    {
        logger.LogDebug("{callerMemberName} start.", callerMemberName);
        try
        {
            executor();
            logger.LogDebug("{callerMemberName} end.", callerMemberName);
        }
        catch (Exception ex)
        {
            logger.LogCritical("{callerMemberName} abend. {message}", callerMemberName, ex.Message);
            throw;
        }
    }

    public static TResult Execute<TResult>(this IGw _, ILogger logger, Func<TResult> executor, [CallerMemberName] string? callerMemberName = null)
    {
        logger.LogDebug("{callerMemberName} start.", callerMemberName);
        try
        {
            var result = executor();
            logger.LogDebug("{callerMemberName} end.", callerMemberName);
            return result;
        }
        catch (Exception ex)
        {
            logger.LogCritical("{callerMemberName} abend. {message}", callerMemberName, ex.Message);
            throw;
        }
    }

    public static async Task<TResult> ExecuteAsync<TResult>(this IGw _, ILogger logger, Func<TResult> executor, [CallerMemberName] string? callerMemberName = null)
    {
        logger.LogDebug("{callerMemberName} start.", callerMemberName);
        try
        {
            var result = await Task.Run(() => executor());
            logger.LogDebug("{callerMemberName} end.", callerMemberName);
            return result;
        }
        catch (Exception ex)
        {
            logger.LogCritical("{callerMemberName} abend. {message}", callerMemberName, ex.Message);
            throw;
        }
    }

    public static T AddTo<T>(this T self, ICollection<IDisposable> container)
        where T : IDisposable
    {
        container.Add(self);
        return self;
    }

    public static int Multiply(this int self, decimal value) =>
        (int)Math.Floor(self * value);

}
