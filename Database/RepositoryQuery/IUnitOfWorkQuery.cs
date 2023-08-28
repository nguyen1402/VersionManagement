using SC.NewsApi.Database.RepositoryQuery.Interfaces;
using SC.VersionManagement.Database.RepositoryQuery.Interfaces;
using System;

namespace SC.VersionManagement
{
    public interface IUnitOfWorkQuery : IDisposable
    {
        bool CreateTransaction();
        void Commit();
        IVersionLockDateRepositoryQuery VersionLockDateRepositoryQuery { get; }
        IApplicationRepositoryQuery ApplicationRepositoryQuery { get; }
        IVersionEnvironmentRepositoryQuery VersionEnvironmentRepositoryQuery { get; }
    }
}
