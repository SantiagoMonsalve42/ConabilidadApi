using Microsoft.Extensions.Logging;

namespace Common.Utilities
{
    public class LoggerSp<TCategoryName> : ILoggerSp<TCategoryName>
    {
        private readonly ILogger<TCategoryName> logger;

        public LoggerSp(ILogger<TCategoryName> _logger)
        {
            logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public Task<bool> setError(Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return Task.FromResult(true);
        }

        public Task<bool> setLog(string message)
        {
            logger.LogInformation(message);
            return Task.FromResult(true);
        }
    }
}
