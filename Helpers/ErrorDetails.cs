using Newtonsoft.Json;
using System.Collections.Generic;

namespace SC.VersionManagement.Helpers
{
    public class ErrorDetails
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<ApiError> Errors { get; set; }

        public ErrorDetails(ApiError error) : this()
        {
            Errors.Add(error);
        }

        public ErrorDetails(ICollection<ApiError> errors) : this()
        {
            Errors = errors;
        }

        public ErrorDetails(string message) : this()
        {
            Errors.Add(new ApiError
            {
                Message = message
            });
        }

        public ErrorDetails(string code, string message) : this()
        {
            Errors.Add(
                new ApiError
                {
                    Code = code,
                    Message = message
                });
        }

        public ErrorDetails()
        {
            Errors = new List<ApiError>();
        }
    }

    public class ApiError
    {
        //ErrorDate
        //Ip
        //Domain

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object MoreInfo { get; set; }
    }
}
