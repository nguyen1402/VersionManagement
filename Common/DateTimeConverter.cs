using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Security.Claims;

namespace SC.VersionManagement.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DateTimeNullableConverter: JsonConverter<DateTime?>
    {
        private string _timeZone;
        private IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public DateTimeNullableConverter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="hasExistingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return DateTime.Parse(reader.ReadAsString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
        {
            _timeZone = _httpContextAccessor.HttpContext?.User?.FindFirstValue("timeZone") ?? "+07:00";
            writer.WriteValue(value.Value.ToClientTime(_timeZone).ToString("yyyy-MM-ddTTHH:mm:ss"));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private string _timeZone;
        private IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public DateTimeConverter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="hasExistingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return DateTime.Parse(reader.ReadAsString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            _timeZone = _httpContextAccessor.HttpContext?.User?.FindFirstValue("timeZone") ?? "+07:00";
            writer.WriteValue(value.ToClientTime(_timeZone).ToString("yyyy-MM-ddTTHH:mm:ss"));
        }
    }
}
