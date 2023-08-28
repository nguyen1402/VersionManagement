using SC.VersionManagement.Helpers;
using System;


namespace SC.VersionManagement.Extensions
{
    public class SoftComUnauthorizedException : UnauthorizedAccessException
    {
        public const string ErrorCode = "error_code";
        public SoftComUnauthorizedException(string message) : base(message)
        {
        }

        public SoftComUnauthorizedException(string message, int code) : base(message)
        {
            Data.Add(ErrorCode, code);
        }

        public SoftComUnauthorizedException(string exceptionEnum, string exValue = "") : base($"{typeof(ApplicationCode).GetField(exceptionEnum).GetValue(null)} {exValue}")
        {
            Data.Add(ErrorCode, exceptionEnum);
        }
    }
}