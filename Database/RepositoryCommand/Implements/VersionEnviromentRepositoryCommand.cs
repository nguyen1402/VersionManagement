using Dapper;
using System.Data;
using SC.VersionManagement.Database.RepositoryCommand.Interfaces;
using SC.VersionManagement.Database.Entities;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SC.VersionManagement.Database.RepositoryCommand.Implements
{
    internal class VersionEnvironmentRepositoryCommand : RepositoryBase, IVersionEnvironmentRepositoryCommand
    {
        public VersionEnvironmentRepositoryCommand(IDbConnection connection, IDbTransaction transaction)
          : base(connection, transaction)
        { }
        public async Task<long> Add(VersionEnvironment model)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", model.Id, DbType.Guid, ParameterDirection.Input);
                parameter.Add("@IdApplication", model.IdApplication, DbType.Guid, ParameterDirection.Input);
                parameter.Add("@TenantId", model.TenantId, DbType.Int64);
                parameter.Add("@WorkGroupId", model.WorkgroupId, DbType.Int64);
                parameter.Add("@UrlFile", model.UrlFile, DbType.String, ParameterDirection.Input);
                parameter.Add("@Description", model.Description, DbType.String, ParameterDirection.Input);
                parameter.Add("@Enviroment", model.Environment, DbType.Int64, ParameterDirection.Input);
                parameter.Add("@Active", model.Active, DbType.Boolean, ParameterDirection.Input);
                parameter.Add("@CreatedBy", model.CreatedBy, DbType.Int64, ParameterDirection.Input);
                parameter.Add("@ResponseStatus", DBNull.Value, DbType.Int64, direction: ParameterDirection.Output);

                var affectedRows = await _dbConnection.ExecuteAsync("SP_VersionEnvironment_Insert", parameter, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
                long resultStatus = parameter.Get<long>("@ResponseStatus");
                return resultStatus;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<List<string>> GetListUrlByIdNameVersion(Guid id, int environment)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@IdApplication", id, DbType.Guid, ParameterDirection.Input);
            parameter.Add("@Environment", environment, DbType.Int64, ParameterDirection.Input);
            var data = await _dbConnection.QueryAsync<string>("SP_VersionEnvironment_GetListUrlByIdNameVersion", parameter, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
            if (data == null || data.Count() == 0)
                return null;
            return data.ToList();
        }

        public async Task<long> UpdateActive(VersionEnvironment model)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", model.Id, DbType.Guid, ParameterDirection.Input);
                parameter.Add("@TenantId", model.TenantId, DbType.Int64);
                parameter.Add("@WorkGroupId", model.WorkgroupId, DbType.Int64);
                parameter.Add("@LastEditedBy", model.LastEditedBy, DbType.Int64, ParameterDirection.Input);
                parameter.Add("@ResponseStatus", DBNull.Value, DbType.Int64, direction: ParameterDirection.Output);
                var affectedRows = await _dbConnection.ExecuteAsync("SP_VersionEnvironment_UpdateActive", parameter, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
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
