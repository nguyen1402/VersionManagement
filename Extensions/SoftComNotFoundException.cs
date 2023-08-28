using SC.VersionManagement.Helpers;

namespace SC.VersionManagement.Extensions
{
    public class SoftComNotFoundException : System.Exception
    {
        public const string ErrorCode = "error_code";

        public SoftComNotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public SoftComNotFoundException(string exceptionEnum, string exValue = "") : base($"{typeof(ApplicationCode).GetField(exceptionEnum).GetValue(null)} {exValue}")
        {
            Data.Add(ErrorCode, exceptionEnum);
        }
    }
}