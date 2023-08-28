using Dapper;
using SC.VersionManagement.Database.Entities;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SC.VersionManagement.Database.RepositoryQuery.Interfaces;
using SC.VersionManagement.Database.Models.Request;
using System.Collections.Generic;

namespace SC.VersionManagement.Database.RepositoryQuery.Implements
{
    internal class ApplicationRepositoryQuery : RepositoryBase, IApplicationRepositoryQuery
    {
        public ApplicationRepositoryQuery(IDbConnection connection, IDbTransaction transaction)
          : base(connection, transaction)
        { }
        public async Task<Application> GetDetailById(Guid id, long TenantId, long TenantWgId)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", id, DbType.Guid, ParameterDirection.Input);
            parameter.Add("@TenantId", TenantId, DbType.Int64);
            parameter.Add("@WorkGroupId", TenantWgId, DbType.Int64);
            var data = await _dbConnection.QueryAsync<Application>("SP_Application_GetDetailById", parameter, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
            if (data == null || data.Count() == 0)
                return new Application();
            return data.FirstOrDefault();
        }
        public async Task<List<Application>> GetByPage(ApplicationRequestFillterQuery model, long tenantId, long workgroupId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantId", tenantId, DbType.Int64);
            parameters.Add("@WorkGroupId", workgroupId, DbType.Int64);
            parameters.Add("@Keyword", model.KeyWord, DbType.String, size: 512);
            parameters.Add("@PageNumber", model.PageIndex, DbType.Int32);
            parameters.Add("@PageSize", model.PageSize, DbType.Int32);
            parameters.Add("@Orderby", model.OrderByDesc, DbType.Boolean);
            parameters.Add("@FieldName", model.FieldName, DbType.String, size: 64);
            var data = _dbConnection.Query<Application>("SP_Application_FeGetByPage", parameters, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
    }
}