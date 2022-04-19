namespace Common.Utilities
{
    public interface ILoggerSp<TCategoryName>
    {
        Task<bool> setError(Exception ex);
        Task<bool> setLog(string message);
    }
}
