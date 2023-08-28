using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;

namespace SC.VersionManagement.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Kiểm tra 1 chuỗi có phải là tên thuộc tính của 1 object hay không
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool IsPropertyName<T>(this string propertyName)
        {
            var properties = typeof(T).GetProperties();
            foreach (var p in properties)
            {
                if (p.Name.ToLower().Equals(propertyName.ToLower())) return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Stringify(this object obj)
        {
            if (obj == null) return null;
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
        /// <summary>
        /// 
        /// </summary>
        public static T Parse<T>(this string json)
        {
            if (string.IsNullOrEmpty(json)) return default;
            return JsonConvert.DeserializeObject<T>(json);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Unsigned(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ",   "ặ",
                "đ",
                "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                "í","ì","ỉ","ĩ","ị",
                "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",   "a",
                "d",
                "e","e","e","e","e","e","e","e","e","e","e",
                "i","i","i","i","i",
                "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                "u","u","u","u","u","u","u","u","u","u","u",
                "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                str = str.Replace(arr1[i], arr2[i]);
                str = str.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        public static DateTime ToClientTime(this DateTime dateTime, string timeZone)
        {
            TimeSpan utcOffset = ParseOffset(timeZone);
            TimeZoneInfo tzi = TimeZoneInfo.CreateCustomTimeZone("custom id", utcOffset, null, null);
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, tzi);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        public static DateTime? ToClientTime(this DateTime? dateTime, string timeZone)
        {
            if (dateTime == null) return null;
            TimeSpan utcOffset = ParseOffset(timeZone);
            TimeZoneInfo tzi = TimeZoneInfo.CreateCustomTimeZone("custom id", utcOffset, null, null);
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime.Value, tzi);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        public static DateTime? ToClientTime(this DateTime? dateTime, IHttpContextAccessor httpContextAccessor)
        {
            if (dateTime == null) return null;
            var timeZone = httpContextAccessor.HttpContext?.User?.FindFirstValue("timeZone") ?? "+07:00";
            TimeSpan utcOffset = ParseOffset(timeZone);
            TimeZoneInfo tzi = TimeZoneInfo.CreateCustomTimeZone("custom id", utcOffset, null, null);
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime.Value, tzi);
        }

        static TimeSpan ParseOffset(string s)
        {
            var ts = TimeSpan.ParseExact(s.Substring(1), @"hh\:mm", CultureInfo.InvariantCulture);
            return s[0] == '-' ? ts.Negate() : ts;
        }

        public static string ConvertToUtcTime(this DateTime datetime, TimeZoneInfo timezone)
        {
            try
            {
                DateTime sTime = TimeZoneInfo.ConvertTimeToUtc(datetime, timezone);
                return sTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                return DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        public static string ConvertFromUtcTime(this DateTime datetime, TimeZoneInfo timezone)
        {
            try
            {
                DateTime sTime = TimeZoneInfo.ConvertTimeFromUtc(datetime, timezone);
                return sTime.ToString("yyyy-MM-dd hh:mm:ss");
            }
            catch
            {
                return DateTime.MinValue.ToString("yyyy-MM-dd hh:mm:ss");
            }
        }

        //public static string ConvertFromUtcTime(this DateTime? datetime, TimeZoneInfo timezone)
        //{
        //    try
        //    {
        //        var dateTime = Convert.ToDateTime(datetime);

        //        if (datetime == null || dateTime == DateTime.MinValue)
        //        {
        //            return DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
        //        }
        //        else
        //        {
        //            DateTime sTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, timezone);
        //            return sTime.ToString("yyyy-MM-dd HH:mm:ss");
        //        }
        //    }
        //    catch
        //    {
        //        return DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
        //    }
        //}

        public static string ConvertFromUtcTimeNotNull(this DateTime datetime, TimeZoneInfo timezone)
        {
            try
            {
                var dateTime = Convert.ToDateTime(datetime);

                if (datetime == null || dateTime == DateTime.MinValue)
                {
                    return DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    DateTime sTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, timezone);
                    return sTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            catch
            {
                return DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static TimeSpan GetTimeZoneByCountryCode(string countryCode)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(f => f.Id.StartsWith(countryCode));
            return timeZoneInfo.BaseUtcOffset;
        }
    }
}
