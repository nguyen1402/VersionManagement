using SC.BaseObject.Entities;
using SC.VersionManagement.Enum;
using System;

namespace SC.VersionManagement.Database.Models.Response
{
    public class VersionEnviromentResponse
    {
        public string Name { get; set; }
        public string UrlFile { get; set; }
        public string Description { get; set; }
        public EnumEnviroment Enviroment { get; set; }
        public float Version { get; set; }
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
    }

    public class VersionEnvironmentResponse : SCBaseEntity<Guid>
    {
        public string UrlFile { get; set; }
        public string Description { get; set; }
        public EnumEnviroment Enviroment { get; set; }
        public float Version { get; set; }
    }
    public class DataItem
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Thumb { get; set; }
    }
}
