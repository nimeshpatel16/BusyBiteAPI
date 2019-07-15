using Dapper;
using Envision.MDM.Location.Domain.AggregatesModel;
using Envision.MDM.Location.Domain.Common;
using Envision.MDM.Location.Infrastructure.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Location.Infrastructure.Repositories.Queries
{
    public class AllAgentQueriesRepository : IAllAgentQueriesRepository 
    {

        private readonly string _connectionString = string.Empty;

        public AllAgentQueriesRepository(string connString)
        {
            _connectionString = !string.IsNullOrEmpty(connString) ? connString : throw new ArgumentNullException(nameof(connString));
        }

        public Task<IEnumerable<AgentInfo>> GetList(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AgentInfo>> GetList(string AgentName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();

                param.Add("@AgName", AgentName, DbType.String);

                var result = await connection.QueryAsync<PAgent>("[dbo].[usp_GETAgentDetails]",
                    param, commandType: CommandType.StoredProcedure);

                return MapItemList(result.AsList());

            }
        }

        public Task<AgentInfo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private static AgentInfo MapCompanyItem(dynamic results)
        {
            var compInfo = new AgentInfo(results[0].AgentId, results[0].AgentName);

            return compInfo;
        }

        private static IEnumerable<AgentInfo> MapItemList(List<PAgent> lstObj)
        {

            var lstResult = from item in lstObj
                          select new AgentInfo(item.AgentId)
                              {
                                  agentId = item.AgentId,
                                  agentName = item.AgentName,
                                  
                              };

            return lstResult;
        }

       
    }
}
