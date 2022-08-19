using DTO.Common;

namespace Common.Utilities
{
    public class ExceptionHandle : IExceptionHandle
    {
        private readonly ILoggerSp<ExceptionHandle> logger;

        public ExceptionHandle(ILoggerSp<ExceptionHandle> _logger)
        {
            logger = _logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public HttpResponseDto GenericException(Exception ex)
        {
            _ = logger.setError(ex);
            return new HttpResponseDto()
            {
                Data = null,
                Error = ex.Message
            };
        }
    }
}
