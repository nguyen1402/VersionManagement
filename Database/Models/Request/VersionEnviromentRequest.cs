using Microsoft.AspNetCore.Http;
using SC.VersionManagement.Enum;
using SC.VersionManagement.Models;
using System;

namespace SC.VersionManagement.Database.Models.Request
{

    public class VersionEnviromentRequest
    {
    }

    public class VersionEnviromentCreateRequest
    {
        public Guid IdApplication { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public EnumEnviroment Environment { get; set; }
        public bool Active { get; set; }
    }

    public class VersionEnvironmentRequestFilterQuery : PagingQuery
    {
        public string KeyWord { get; set; }
    }
}
