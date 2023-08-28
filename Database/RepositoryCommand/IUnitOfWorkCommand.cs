using SC.VersionManagement.Database.RepositoryCommand.Interfaces;
using System;

namespace SC.VersionManagement
{
    public interface IUnitOfWorkCommand:IDisposable
    {
        bool CreateTransaction();
        void Commit();
        IVersionLockDateRepositoryCommand VersionLockDateRepositoryCommand { get; }
        IVersionEnvironmentRepositoryCommand VersionEnvironmentRepositoryCommand { get; }
        IApplicationRepositoryCommand ApplicationRepositoryCommand { get; }
    }
}
