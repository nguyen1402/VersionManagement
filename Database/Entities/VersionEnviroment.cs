using SC.BaseObject.Entities;
using Newtonsoft.Json;
using System;

namespace SC.VersionManagement.Database.Entities
{
    public class VersionEnvironment : SCBaseEntity<Guid>
    {
        public Guid IdApplication { get; set; }
        public string UrlFile { get; set; }
        public string Description { get; set; }
        public int Environment { get; set; }
        public float Version { get; set; }

        [JsonIgnore]
        public int TotalRows { get; set; }
    }
    public class VersionEnvironmentName : SCBaseEntity<Guid>
    {
        public string Name { get; set; }
        public string UrlFile { get; set; }
        public string Description { get; set; }
        public int Environment { get; set; }
        public float Version { get; set; }

        [JsonIgnore]
        public int TotalRows { get; set; }
    }
}
