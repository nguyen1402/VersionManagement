using SC.VersionManagement.Database.Entities;
using System.Threading.Tasks;

namespace SC.VersionManagement.Database.RepositoryCommand.Interfaces
{
    public interface IApplicationRepositoryCommand
    {
        Task<long> Add(Application model);
        Task<long> Update(Application model);
    }
}
