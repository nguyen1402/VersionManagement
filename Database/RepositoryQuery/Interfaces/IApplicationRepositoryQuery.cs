using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database.Models.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.VersionManagement.Database.RepositoryQuery.Interfaces
{
    public interface IApplicationRepositoryQuery
    {
        Task<Application> GetDetailById(Guid id,long TenantId,long TenantWgId);
        Task<List<Application>> GetByPage(ApplicationRequestFillterQuery model, long tenantId, long workgroupId);
    }
}
