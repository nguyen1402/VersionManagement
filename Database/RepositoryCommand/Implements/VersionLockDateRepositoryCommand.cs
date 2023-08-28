using Dapper;
using System.Data;
using SC.VersionManagement.Database.RepositoryCommand.Interfaces;
using SC.VersionManagement.Database.Entities;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using SC.VersionManagement.Database.Models.Request;
using SC.VersionManagement.Common;

namespace SC.VersionManagement.Database.RepositoryCommand.Implements
{
    internal class VersionLockDateRepositoryCommand : RepositoryBase, IVersionLockDateRepositoryCommand
    {
        public VersionLockDateRepositoryCommand(IDbConnection connection, IDbTransaction transaction)
          : base(connection, transaction)
        { }
        public async Task<long> Add(VersionLockDate model)
        {
            try
            {
                var idsStr = model.ListApplicationId == null ? null : string.Join("\',\'", model.ListApplicationId.GroupBy(x => x).Select(g => g.First()));
                idsStr = $"\'{idsStr}\'";

                DynamicParameters _params = new DynamicParameters();
                _params.Add("@Id", model.Id, DbType.Guid, ParameterDirection.Input);
                _params.Add("@TenantId", model.TenantId, DbType.Int64, ParameterDirection.Input);
                _params.Add("@WorkgroupId", model.WorkgroupId, DbType.Int64, ParameterDirection.Input);
                if (model.ListApplicationId != null && model.ListApplicationId.Count() > 0)
                    _params.Add("@ListApplicationId", idsStr, DbType.String, ParameterDirection.Input);
                _params.Add("@Enviroment", model.Enviroment, DbType.Int32, ParameterDirection.Input);
                _params.Add("@CreatedBy", model.CreatedBy, DbType.Int64, ParameterDirection.Input);
                _params.Add("@CreatedByName", model.CreatedByName, DbType.String, ParameterDirection.Input);
                _params.Add("@ResponseStatus", DBNull.Value, DbType.Int64, direction: ParameterDirection.Output);
               
                var affectedRows = _dbConnection.Execute("SP_VersionLockDate_Insert", _params, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
                long resultStatus = _params.Get<long>("@ResponseStatus");
                return resultStatus;
            }
            catch (Exception e)
            {

            }
            return -1;
        }
        public async Task<long> UpdateIsPublic(VersionLockDate model)
        {
            

            DynamicParameters _params = new DynamicParameters();
            _params.Add("@Id", model.Id, DbType.Guid, ParameterDirection.Input);
            _params.Add("@TenantId", model.TenantId, DbType.Int64, ParameterDirection.Input);
            _params.Add("@WorkgroupId", model.WorkgroupId, DbType.Int64, ParameterDirection.Input);
            _params.Add("@LastEditedBy", model.LastEditedBy, DbType.Int64, ParameterDirection.Input);
            _params.Add("@LastEditedByName", model.LastEditedByName, DbType.String, ParameterDirection.Input, size: 128);
            _params.Add("@ResponseStatus", DBNull.Value, DbType.Int64, direction: ParameterDirection.Output);

            var affectedRows = _dbConnection.Execute("SP_VersionLockDate_UpdatePublic", _params, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
            long resultStatus = _params.Get<long>("@ResponseStatus");
            return resultStatus;

        } 
        
        public async Task<List<VersionLockDate>> GetByPage(VersionLockDateFillterQuery model, long tenantId, long workgroupId)
        {
            var idsStr = model.ListId == null ? null : string.Join("\',\'", model.ListId.GroupBy(x => x).Select(g => g.First()));
            idsStr = $"\'{idsStr}\'";

          
            var parameters = new DynamicParameters();
            if (model.Active != null)
                parameters.Add("@Active", model.Active, DbType.Boolean);
            if (model.DateTo != null && model.DateTo != DateTime.MinValue)
                parameters.Add("@DateTo", model.DateTo.ConvertToUtcTime(TimeZoneInfo.Utc), DbType.DateTime);
            if (model.DateFrom != null && model.DateFrom != DateTime.MinValue)
                parameters.Add("@DateFrom", model.DateFrom.ConvertToUtcTime(TimeZoneInfo.Utc), DbType.DateTime);

            if (model.ListId != null && model.ListId.Count() > 0)
                parameters.Add("@ListId", idsStr, DbType.String, size: 1000000000);

            parameters.Add("@TenantId",tenantId, DbType.Int64);
            parameters.Add("@WorkGroupId", workgroupId, DbType.Int64);
            parameters.Add("@Keyword", model.KeyWord, DbType.String, size: 512);
            parameters.Add("@PageNumber", model.PageIndex, DbType.Int32);
            parameters.Add("@PageSize", model.PageSize, DbType.Int32);
            parameters.Add("@Orderby", model.OrderByDesc, DbType.Boolean);
            parameters.Add("@FieldName", model.FieldName, DbType.String, size: 64);

            var data = _dbConnection.Query<VersionLockDate>("SP_VersionLockDate_FeGetByPage", parameters, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);

            return data.ToList();
        }
    }
}
