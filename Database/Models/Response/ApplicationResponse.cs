using SC.BaseObject.Entities;
using System;

namespace SC.VersionManagement.Database.Models.Response
{
    public class ApplicationResponse : SCBaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
