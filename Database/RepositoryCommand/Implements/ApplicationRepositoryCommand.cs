using Dapper;
using SC.VersionManagement.Database;
using SC.VersionManagement.Database.Entities;
using System;
using System.Data;
using System.Threading.Tasks;
using SC.VersionManagement.Database.RepositoryCommand.Interfaces;

namespace VersionManagement.Database.RepositoryCommand.Implements
{
    internal class ApplicationRepositoryCommand : RepositoryBase, IApplicationRepositoryCommand
    {
        public ApplicationRepositoryCommand(IDbConnection connection, IDbTransaction transaction)
          : base(connection, transaction)
        { }
        public async Task<long> Add(Application model)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", model.Id, DbType.Guid, ParameterDirection.Input);
                parameters.Add("@Name", model.Name, DbType.String, ParameterDirection.Input);
                parameters.Add("@TenantId", model.TenantId, DbType.Int64);
                parameters.Add("@WorkGroupId", model.WorkgroupId, DbType.Int64);
                parameters.Add("@Description", model.Description, DbType.String, ParameterDirection.Input);
                parameters.Add("@CreatedBy", model.CreatedBy, DbType.Int64, ParameterDirection.Input);
                parameters.Add("@CreatedByName", model.CreatedBy, DbType.Int64, ParameterDirection.Input);
                parameters.Add("@ResponseStatus", DBNull.Value, DbType.Int64, direction: ParameterDirection.Output);
                var affectedRows = await _dbConnection.ExecuteAsync("SP_Application_Insert", parameters, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
                long resultStatus = parameters.Get<long>("@ResponseStatus");
                return resultStatus;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<long> Update(Application model)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", model.Id, DbType.Guid, ParameterDirection.Input);
                parameter.Add("@TenantId", model.TenantId, DbType.Int64);
                parameter.Add("@WorkGroupId", model.WorkgroupId, DbType.Int64);
                parameter.Add("@Name", model.Name, DbType.String, ParameterDirection.Input);
                parameter.Add("@Description", model.Description, DbType.String, ParameterDirection.Input);
                parameter.Add("@ModifiedBy", model.LastEditedBy, DbType.Int64, ParameterDirection.Input);
                parameter.Add("@ResponseStatus", DBNull.Value, DbType.Int64, direction: ParameterDirection.Output);
                var affectedRows = await _dbConnection.ExecuteAsync("SP_Application_Update", parameter, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
                long resultStatus = parameter.Get<long>("@ResponseStatus");
                return resultStatus;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
