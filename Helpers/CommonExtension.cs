using System;

namespace SC.VersionManagement.Helpers
{
    public static class CommonExtension
    {
    }

    public static class GuidExtensions
    {
        public static bool IsGuid(string value)
        {
            Guid x;
            return Guid.TryParse(value, out x);
        }
    }

    public static class JsonExtentions
    {
        public static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                   || input.StartsWith("[") && input.EndsWith("]");
        }
    }
}
