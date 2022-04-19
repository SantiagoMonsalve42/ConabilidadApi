namespace Contabilidad_api.Filters
{
    public class ValidationError
    {
        public string Attribute { get; }

        public string Message { get; }

        public ValidationError(string attribute, string message)
        {
            Attribute = attribute;
            Message = message;
        }
    }
}
