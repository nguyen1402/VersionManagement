using SC.VersionManagement.Helpers;
using System.Globalization;

namespace SC.VersionManagement.Extensions
{
    public class SoftComException : System.Exception
    {
        public const string ErrorCode = "error_code";

        public SoftComException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture,
            message, args))
        {
        }

        public SoftComException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
        public SoftComException(string exceptionEnum, string exValue = "") : base($"{typeof(ApplicationCode).GetField(exceptionEnum).GetValue(null)} {exValue}")
        {
            Data.Add(ErrorCode, exceptionEnum);
        }
    }
}