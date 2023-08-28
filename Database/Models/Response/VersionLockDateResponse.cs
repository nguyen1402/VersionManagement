using SC.VersionManagement.Database.Models.Response;
using SC.VersionManagement.Enum;
using System;
using System.Collections.Generic;

namespace VersionManagement.Database.Models.Response
{
    public class VersionLockDateResponse
    {
        public EnumEnviroment Enviroment { get; set; }
        public bool IsPublic { get; set; }

        public Guid Id { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public long CreatedDateUnixTime { get; set; }

        public long CreatedBy { get; set; }

        public string CreatedByName { get; set; }

        public DateTime LastEditedDate { get; set; }

        public long LastEditedDateUnixTime { get; set; }

        public long LastEditedBy { get; set; }

        public string LastEditedByName { get; set; }
        public List<VersionEnviromentResponse> ListVersionEnviroments { get; set; }


    }
}
