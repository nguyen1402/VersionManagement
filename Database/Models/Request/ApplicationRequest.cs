using SC.VersionManagement.Enum;
using System.Collections.Generic;
using System;
using SC.VersionManagement.Models;

namespace SC.VersionManagement.Database.Models.Request
{
    public class ApplicationRequest
    {
       
    }

    public class ApplicationCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ApplicationUpdateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ApplicationRequestFillterQuery : PagingQuery
    {
        public string KeyWord { get; set; }
    }
}
