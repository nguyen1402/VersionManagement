using System.Data;

namespace SC.VersionManagement.Database
{
    internal abstract class RepositoryBase
    {
        protected IDbTransaction _dbTransaction { get; private set; }
        //protected IDbConnection _dbConnection { get { return _dbTransaction.Connection; } }
        protected IDbConnection _dbConnection { get; private set; }

        public RepositoryBase(IDbConnection dbConnection, IDbTransaction dbTransaction)
        {
            _dbConnection = dbConnection;
            _dbTransaction = dbTransaction;
        }
    }
}
