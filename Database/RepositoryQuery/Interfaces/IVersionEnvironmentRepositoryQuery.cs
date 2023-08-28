using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.NewsApi.Database.RepositoryQuery.Interfaces
{
    public interface IVersionEnvironmentRepositoryQuery
    {
        Task<List<VersionEnvironment>> GetByPage(VersionEnvironmentRequestFilterQuery model, long tenantId, long workgroupId);
    }
}
