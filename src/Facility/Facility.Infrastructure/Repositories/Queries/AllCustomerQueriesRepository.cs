using Dapper;
using Envision.MDM.Location.Domain.AggregatesModel;
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
    public class AllCompanyQueriesRepository : IAllCompanyQueriesRepository 
    {

        private readonly string _connectionString = string.Empty;

        public AllCompanyQueriesRepository(string connString)
        {
            _connectionString = !string.IsNullOrEmpty(connString) ? connString : throw new ArgumentNullException(nameof(connString));
        }

        public Task<IEnumerable<CompanyInfo>> GetList(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompanyInfo>> GetList(string CompanyName)
        {
            try
            {


                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var param = new DynamicParameters();

                    param.Add("@CCName", CompanyName, DbType.String);

                    var result = await connection.QueryAsync<PCompanyInfo>("[dbo].[usp_GETCompanyDetails]",
                        param, commandType: CommandType.StoredProcedure);

                    return MapCompanyItemList(result.AsList());

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<CompanyInfo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private static CompanyInfo MapCompanyItem(dynamic results)
        {
            var compInfo = new CompanyInfo(results[0].CompanyId, results[0].CompanyName);

            return compInfo;
        }

        private static IEnumerable<CompanyInfo> MapCompanyItemList(List<PCompanyInfo> lstCompany)
        {

            var lstcomp = from item in lstCompany
                              select new CompanyInfo(item.CompanyId)
                              {
                                  CompanyId = item.CompanyId,
                                  CompanyName = item.CompanyName,
                                  
                              };

            return lstcomp;
        }


    }
}
