using SC.BaseObject.Entities;
using SC.VersionManagement.Enum;
using System;
using System.Collections.Generic;

namespace SC.VersionManagement.Database.Entities
{
    public class VersionLockDate : SCBaseEntity<Guid>
    {
        public EnumEnviroment Enviroment { get; set; }
        public bool IsPublic { get; set; }
        public List<Guid> ListApplicationId { get; set; }
       
        public int TotalRows { get; set; } 
        public VersionLockDate()
        {
            ListApplicationId = new List<Guid>();
        }
    }
   
}
