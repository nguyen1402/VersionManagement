using System.Data;
using VersionManagement.Database.RepositoryCommand.Implements;
using SC.VersionManagement.Database.RepositoryCommand.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using SC.VersionManagement.Database.RepositoryCommand.Implements;

namespace SC.VersionManagement
{
    public class UnitOfWorkCommand : IUnitOfWorkCommand
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IApplicationRepositoryCommand _nameVersionRepositoryCommand;
        private IVersionEnvironmentRepositoryCommand _versionEnvironmentRepositoryCommand;
        private bool _disposed;
        private IVersionLockDateRepositoryCommand _versionLockDateRepositoryCommand;
        public UnitOfWorkCommand(string connectionString)
        {
            try
            {
                _connection = new SqlConnection(FixConnectString(connectionString, true));
                _connection.Open();
                //_transaction = _connection.BeginTransaction();
            }
            catch (Exception)
            {
                // De phong truong hop bi max pool thi se fix lai connection string pooling=false
                _connection = new SqlConnection(FixConnectString(connectionString, false));
                _connection.Open();
                //_transaction = _connection.BeginTransaction();
            }
        }

        /// <summary>
        /// Transaction chưa tồn tại thì khởi tạo đã tồn tại thì dùng tiếp => dùng trong trường hợp gọi lồng service
        /// Chú ý: Nếu mở ko CreateTransaction mà đã tồn tại tại tran, nghĩa là đang sử dụng Tran được khởi tạo từ service khác thì ko đc được commit
        /// Tại mỗi đầu service check xem có khởi tạo Tran ko? Nếu có khởi tạo thì có thể Commit
        /// </summary>
        public bool CreateTransaction()
        {
            var isCreateTranSaction = false;
            if (_transaction == null)
            {
                _transaction = _connection.BeginTransaction();
                isCreateTranSaction = true;
            }
            return isCreateTranSaction;
        }

        public IVersionLockDateRepositoryCommand VersionLockDateRepositoryCommand
        {
            get { return _versionLockDateRepositoryCommand ?? (_versionLockDateRepositoryCommand = new VersionLockDateRepositoryCommand(_connection, _transaction)); }
        }
        public IVersionEnvironmentRepositoryCommand VersionEnvironmentRepositoryCommand
        {
            get { return _versionEnvironmentRepositoryCommand ?? (_versionEnvironmentRepositoryCommand = new VersionEnvironmentRepositoryCommand(_connection, _transaction)); }

        }

        public IApplicationRepositoryCommand ApplicationRepositoryCommand
        {
            get { return _nameVersionRepositoryCommand ?? (_nameVersionRepositoryCommand = new ApplicationRepositoryCommand(_connection, _transaction)); }
        }

        /// <summary>
        /// Chuẩn hoá connection string
        /// </summary>
        public string FixConnectString(string connStr, bool Pooling)
        {
            var aconnStr = connStr.Split(';');
            var sTemp = "";
            for (var i = 0; i < aconnStr.Length; i++)
            {
                if (aconnStr[i].ToLower().StartsWith("pooling=") ||
                    aconnStr[i].ToLower().StartsWith("min pool size=") ||
                    aconnStr[i].ToLower().StartsWith("max pool size=") ||
                    aconnStr[i].ToLower().StartsWith("connect timeout="))
                {
                    continue;
                }
                if (!aconnStr[i].Equals(""))
                {
                    sTemp += string.Format("{0};", aconnStr[i]);
                }
            }

            if (Pooling)
            {
                sTemp += "Pooling=true;Min Pool Size=5;Max Pool Size=200;Connect Timeout=5;";
            }
            else
            {
                sTemp += "Pooling=false;Connect Timeout=10;";
            }
            return sTemp;
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                //_transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        private void resetRepositories()
        {
            _versionLockDateRepositoryCommand = null;
            _nameVersionRepositoryCommand = null;
            _versionEnvironmentRepositoryCommand = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWorkCommand()
        {
            dispose(false);
        }
    }
}
