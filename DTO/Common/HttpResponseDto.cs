namespace DTO.Common
{
    public class HttpResponseDto<TModel>
    {
        public TModel Data { get; set; }
        public string Error { get; set; }
    }
}
