using SC.VersionManagement.Database.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.VersionManagement.Database.RepositoryCommand.Interfaces
{
    public interface IVersionEnvironmentRepositoryCommand
    {
        Task<long> Add(VersionEnvironment model);
        Task<long> UpdateActive(VersionEnvironment model);
        Task<List<string>> GetListUrlByIdNameVersion(Guid id,int environment);
    }
}
