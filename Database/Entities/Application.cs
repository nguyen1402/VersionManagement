using Newtonsoft.Json;
using SC.BaseObject.Entities;
using System;

namespace SC.VersionManagement.Database.Entities
{
    public class Application : SCBaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public int TotalRows { get; set; }
    }
}
