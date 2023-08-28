using System.Collections.Generic;

namespace SC.VersionManagement.Config
{
    public static class LanguageCode
    {
        public const string VN = "vi-VN";
        public const string KR = "ko-KR";
        public const string US = "en-US";

        public static Dictionary<string, string> LanguageCodes = new Dictionary<string, string>()
        {
            {"VN","vi-VN" },
            {"KR","ko-KR" },
            {"US","en-US" },
        };
    }
}