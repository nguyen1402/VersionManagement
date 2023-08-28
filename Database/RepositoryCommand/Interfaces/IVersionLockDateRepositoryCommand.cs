using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.VersionManagement.Database.RepositoryCommand.Interfaces
{
    public interface IVersionLockDateRepositoryCommand
    {
        Task<long> Add(VersionLockDate model);
        Task<long> UpdateIsPublic(VersionLockDate model);
        Task<List<VersionLockDate>> GetByPage(VersionLockDateFillterQuery model, long tenantId, long workgroupId);
    }
}
