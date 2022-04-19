using Microsoft.Extensions.Configuration;

namespace Common.Utilities
{
    public class HelperConfiguration
    {
        public static IConfiguration Configuration { get; set; }

        public static string NameInit = "AppSettings:";
        private static string ValidateNom(string Key) => !Key.Contains(NameInit) ? $"{NameInit}{Key}" : Key;

         public static string GetParam(string Key, bool IncludeNameConfiguration = true)
         {
             Key = IncludeNameConfiguration ? ValidateNom(Key) : Key;
             return Configuration?.GetValue<string>(Key.Trim()) ?? throw new ArgumentNullException($"Is null {Key}");
         }

         public async Task<string> GetParamAsync(string Key)
         {
             return await Task.FromResult(GetParam(Key));
         }
    }
}
