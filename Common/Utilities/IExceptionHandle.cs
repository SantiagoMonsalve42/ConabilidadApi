using DTO.Common;

namespace Common.Utilities
{
    public interface IExceptionHandle
    {
        HttpResponseDto<object> GenericException(Exception ex);
    }
}
