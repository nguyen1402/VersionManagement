using Dapper;
using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SC.NewsApi.Database.RepositoryQuery.Interfaces;
using SC.VersionManagement.Database.Models.Request;
using System.Linq;

namespace SC.NewsApi.Database.RepositoryQuery.Implements
{
    internal class VersionEnvironmentRepositoryQuery : RepositoryBase, IVersionEnvironmentRepositoryQuery
    {
        public VersionEnvironmentRepositoryQuery(IDbConnection connection, IDbTransaction transaction)
          : base(connection, transaction)
        { }
        public async Task<List<VersionEnvironment>> GetByPage(VersionEnvironmentRequestFilterQuery model, long tenantId, long workgroupId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantId", tenantId, DbType.Int64);
            parameters.Add("@WorkGroupId", workgroupId, DbType.Int64);
            parameters.Add("@Keyword", model.KeyWord, DbType.String, size: 512);
            parameters.Add("@PageNumber", model.PageIndex, DbType.Int32);
            parameters.Add("@PageSize", model.PageSize, DbType.Int32);
            parameters.Add("@Orderby", model.OrderByDesc, DbType.Boolean);
            parameters.Add("@FieldName", model.FieldName, DbType.String, size: 64);
            var data = _dbConnection.Query<VersionEnvironment>("SP_VersionEnviroment_FeGetByPage", parameters, transaction: _dbTransaction, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
    }
}