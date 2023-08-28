using Dapper;
using SC.VersionManagement.Common;
using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database.Models.Request;
using SC.VersionManagement.Database.RepositoryQuery.Interfaces;
using SC.VersionManagement.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SC.VersionManagement.Database.RepositoryQuery.Implements
{
    internal class VersionLockDateRepositoryQuery : RepositoryBase, IVersionLockDateRepositoryQuery
    {
        public VersionLockDateRepositoryQuery(IDbConnection connection, IDbTransaction transaction)
          : base(connection, transaction)
        { }

        public async Task<List<VersionLockDate>> GetByPage(VersionLockDateFillterQuery model,long tenantId , long workgroupId)
        {
            var idsStr = model.ListId == null ? null : string.Join("\',\'", model.ListId.GroupBy(x => x).Select(g => g.First()));
            idsStr = $"\'{idsStr}\'";

            
            var parameters = new DynamicParameters();
            if (model.Active != null)
                parameters.Add("@Active", model.Active, DbType.Boolean);
            if (model.IsPublic != null)
                parameters.Add("@IsPublic", model.IsPublic, DbType.Boolean);
            if (model.DateTo != null && model.DateTo != DateTime.MinValue)
                parameters.Add("@DateTo", model.DateTo.ConvertToUtcTime(TimeZoneInfo.Utc), DbType.DateTime);
            if (model.DateFrom != null && model.DateFrom != DateTime.MinValue)
                parameters.Add("@DateFrom", model.DateFrom.ConvertToUtcTime(TimeZoneInfo.Utc), DbType.DateTime);
             
            if (model.Enviroment != null && model.Enviroment > 0)
                parameters.Add("@Enviroment", model.Enviroment, DbType.Int32);

            if (model.ListId != null && model.ListId.Count() > 0)
                parameters.Add("@ListId", idsStr, DbType.String, size: 1000000000);
          
            parameters.Add("@TenantId",tenantId, DbType.Int64);
            parameters.Add("@WorkGroupId", workgroupId, DbType.Int64);
            parameters.Add("@Keyword", model.KeyWord, DbType.String, size: 512);
            parameters.Add("@PageNumber", model.PageIndex, DbType.Int32);
            parameters.Add("@PageSize", model.PageSize, DbType.Int32);
            parameters.Add("@Orderby", model.OrderByDesc, DbType.Boolean);

            if (!string.IsNullOrEmpty(model.FieldName)) 
                parameters.Add("@FieldName", model.FieldName, DbType.String, size: 64);
          
            var data = _dbConnection.Query<VersionLockDate>("SP_VersionLockDate_FeGetByPage", parameters, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
            
            return data.ToList();
        }
        public async Task<VersionLockDate> GetDetail(EnumEnviroment enviroment,long tenantId , long workgroupId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantId",tenantId, DbType.Int64);
            parameters.Add("@WorkGroupId", workgroupId, DbType.Int64);
            parameters.Add("@Enviroment", enviroment, DbType.Int32);
            var data = _dbConnection.Query<VersionLockDate>("SP_VersionLockDate_GetDetail", parameters, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
            
            return data.FirstOrDefault();
        }

        public async Task<List<VersionEnvironmentName>> GetListVersionEnviromentByVersionLockDateId(VersionLockDate model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantId", model.TenantId, DbType.Int64);
            parameters.Add("@WorkGroupId", model.WorkgroupId, DbType.Int64);
            parameters.Add("@VersionLockDateId", model.Id, DbType.Guid);
            parameters.Add("@ResponseStatus", DBNull.Value, DbType.Int64, direction: ParameterDirection.Output);

            var data = _dbConnection.Query<VersionEnvironmentName>("SP_VersionEnvironment_GetByVersionLockDateId", parameters, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);

            return data.ToList();
        }
    }
}
