using DTO.Common;

namespace Common.Utilities
{
    public interface IExceptionHandle
    {
        HttpResponseDto GenericException(Exception ex);
    }
}
