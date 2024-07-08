using Ju.GundamWars.Const;
using Ju.GundamWars.Domain;
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

    public static int Multiply(this int self, decimal multiplier) =>
        (int)Math.Floor(self * multiplier);

    public static string GetUpText(this IBooster self)
    {
        if (self.Calc == CalcType.Addition)
        {
            return $"+{self.Value}";
        }
        else if (self.Calc == CalcType.Multiplication)
        {
            var value = self.Value * 100;
            if (value % 1 == 0)
            {
                return $"{value:F0}% UP";
            }
            else
            {
                return $"{value.ToString($"F3").TrimEnd('0')}% UP";
            }
        }
        else
        {
            return GwText.Unknown;
        }
    }

}
