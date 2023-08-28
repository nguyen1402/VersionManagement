using SC.VersionManagement.Enum;
using System;
using System.Collections.Generic;
using SC.VersionManagement.Models;

namespace SC.VersionManagement.Database.Models.Request
{
    public class VersionLockDateFillterQuery : PagingQuery
    {
        public string KeyWord { get; set; }
        public EnumEnviroment Enviroment { get; set; }
        public bool? IsPublic { get; set; }
        public bool? Active { get; set; }
        public bool? DateMax { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public List<Guid> ListId { get; set; }
        public VersionLockDateFillterQuery()
        {
            ListId = new List<Guid>();
            KeyWord = string.Empty;
            DateFrom = DateTime.MinValue;
            DateTo = DateTime.MinValue;
        }

    }
}
