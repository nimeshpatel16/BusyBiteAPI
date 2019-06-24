using Dapper;
using Envision.MDM.Location.Domain.AggregatesModel;

using Envision.MDM.Location.Infrastructure.Entity.POCO;
using Envision.MDM.Location.Infrastructure.POCO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Location.Infrastructure.Repositories.Queries
{
    public class OutStandingQueriesRepository : IOutStandingQueriesRepository
    {
        private readonly string _connectionString = string.Empty;

        public OutStandingQueriesRepository(string connString)
        {
            _connectionString = !string.IsNullOrEmpty(connString) ? connString : throw new ArgumentNullException(nameof(connString));
        }



        public async Task<OutStanding> GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@CCode", id, DbType.Int32);


                var result = await connection.QueryAsync<POutStanding>("SPSalesOutstanding_NP",
                    param, commandType: CommandType.StoredProcedure);

                if (result.AsList().Count == 0)
                {
                    throw new KeyNotFoundException();
                }

                return MapOutStandingItem(result);
            }
        }

        public Task<IEnumerable<OutStanding>> GetList(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        private static OutStanding MapOutStandingItem(dynamic results)
        {
            
            var outStanding = new OutStanding();
            outStanding.Id = results[0].Id;
            return outStanding;
        }

        private static IEnumerable<OutStanding> MapOutStandingItemList(List<POutStanding> lstoutStanding)
        {

            var lstoutstanding = from item in lstoutStanding
                                 select new OutStanding()
                                 {
                                     Id = item.Id,
                                  CCOde = item.CCOde,
                                  FYear = item.FYear
                                  
                              };

            return lstoutstanding;
        }
    }
}
