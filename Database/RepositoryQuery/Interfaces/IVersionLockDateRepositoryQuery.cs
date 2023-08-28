using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database.Models.Request;
using SC.VersionManagement.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.VersionManagement.Database.RepositoryQuery.Interfaces
{
    public interface IVersionLockDateRepositoryQuery
    {
        Task<List<VersionLockDate>> GetByPage(VersionLockDateFillterQuery model, long tenantId, long workgroupId);
        Task<List<VersionEnvironmentName>> GetListVersionEnviromentByVersionLockDateId(VersionLockDate model);
        Task<VersionLockDate> GetDetail(EnumEnviroment enviroment,long tenantId, long workgroupId);
    }
}
