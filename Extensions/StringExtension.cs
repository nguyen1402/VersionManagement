using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SC.VersionManagement.Extensions
{
    public static class StringExtension
    {
        public static string ToUrlSlug(this string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return string.Empty;
            }

            var str = phrase.ToLower();
            str = Regex.Replace(str, @"\s+", "-");
            str = Regex.Replace(str, @"à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ|å", "a");
            str = Regex.Replace(str, @"è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ|ë|ĕ|ȇ", "e");
            str = Regex.Replace(str, @"ì|í|ị|ỉ|ĩ|Ì|Í|Ị|Ỉ|Ĩ|î|ï", "i");
            str = Regex.Replace(str, @"ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ|ø", "o");
            str = Regex.Replace(str, @"ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ|ů|û", "u");
            str = Regex.Replace(str, @"ỳ|ý|ỵ|ỷ|ỹ|Ỳ|Ý|Ỵ|Ỷ|Ỹ", "y");
            str = Regex.Replace(str, @"đ|ď|Đ", "d");
            str = Regex.Replace(str, @"ç|č|ć", "c");
            str = Regex.Replace(str, @"ň", "n");
            str = Regex.Replace(str, @"ä|æ", "ae");
            str = Regex.Replace(str, @"ö", "oe");
            str = Regex.Replace(str, @"ü", "ue");
            str = Regex.Replace(str, @"Ä", "Ae");
            str = Regex.Replace(str, @"Ö", "Oe");
            str = Regex.Replace(str, @"ß", "ss");
            str = Regex.Replace(str, @"ğ", "g");
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"\s+", " ").Trim();
            str = Regex.Replace(str, @"\-+", "-").Trim('-');

            return str;
        }
        public static string RemoveSign(this string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return string.Empty;
            }
            var str = phrase;
            str = Regex.Replace(str, @"à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ|å", "a");
            str = Regex.Replace(str, @"è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ|ë|ĕ|ȇ", "e");
            str = Regex.Replace(str, @"ì|í|ị|ỉ|ĩ|Ì|Í|Ị|Ỉ|Ĩ|î|ï", "i");
            str = Regex.Replace(str, @"ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ|ø", "o");
            str = Regex.Replace(str, @"ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ|ů|û", "u");
            str = Regex.Replace(str, @"ỳ|ý|ỵ|ỷ|ỹ|Ỳ|Ý|Ỵ|Ỷ|Ỹ", "y");
            str = Regex.Replace(str, @"đ|ď|Đ", "d");
            str = Regex.Replace(str, @"ç|č|ć", "c");
            str = Regex.Replace(str, @"ň", "n");
            str = Regex.Replace(str, @"ä|æ", "ae");
            str = Regex.Replace(str, @"ö", "oe");
            str = Regex.Replace(str, @"ü", "ue");
            str = Regex.Replace(str, @"Ä", "Ae");
            str = Regex.Replace(str, @"Ö", "Oe");
            str = Regex.Replace(str, @"ß", "ss");
            str = Regex.Replace(str, @"ğ", "g");
            return str;
        }
        public static bool TryConvertToDate(this string phrase, out DateTime date)
        {
            return DateTime.TryParseExact(phrase, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
        public static Guid ToGuid(this string str)
        {
            Guid.TryParse(str, out var result);
            return result;
        }

        public static long ToInt64(this string str)
        {
            Int64.TryParse(str, out var result);
            return result;
        }

        public static bool IsValid(this string str)
        {
            return !string.IsNullOrWhiteSpace(str) || !string.IsNullOrEmpty(str);
        }
    }
}