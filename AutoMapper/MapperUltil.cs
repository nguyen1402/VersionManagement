using SC.VersionManagement.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SC.VersionManagement
{
    public class MapperUltil
    {
        private static readonly TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        public static string GetDataFromDic(Dictionary<string, string> dict, string key)
        {
            var data = string.Empty;
            if (dict != null)
            {
                if (dict.TryGetValue(key, out data))
                {
                    return data;
                }
            }

            return string.Empty;
        }

        public static DateTime FormatDatetimeFromUtcTime(DateTime? date)
        {
            if (date == null || date == DateTime.MinValue)
                return DateTime.MinValue;

            DateTime localDate = DateTime.ParseExact(((DateTime)date).ConvertFromUtcTime(timeZone), "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);
            return localDate;
        }
    }
}
