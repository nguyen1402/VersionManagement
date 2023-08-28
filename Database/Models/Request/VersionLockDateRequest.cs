using SC.VersionManagement.Enum;
using System;
using System.Collections.Generic;

namespace SC.VersionManagement.Database.Models.Request
{
    public class VersionLockDateRequest 
    {
    }
    public class VersionLockDateCreateRequest
    {
        public EnumEnviroment Enviroment { get; set; }
        public List<Guid> ListApplicationId { get; set; }
        public VersionLockDateCreateRequest()
        {
            ListApplicationId = new List<Guid>();
        }
    }
    

}
