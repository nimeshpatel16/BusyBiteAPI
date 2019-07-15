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
    public class AllSupplierQueriesRepository : IAllSupplierQueriesRepository 
    {

        private readonly string _connectionString = string.Empty;

        public AllSupplierQueriesRepository(string connString)
        {
            _connectionString = !string.IsNullOrEmpty(connString) ? connString : throw new ArgumentNullException(nameof(connString));
        }

        public Task<IEnumerable<CompanyInfo>> GetList(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SupplierInfo>> GetList(string SupplierName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();

                param.Add("@SName", SupplierName, DbType.String);

                var result = await connection.QueryAsync<PSupplier>("[dbo].[usp_GETSupplierDetails]",
                    param, commandType: CommandType.StoredProcedure);

                return MapItemList(result.AsList());

            }
        }

        public Task<SupplierInfo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private static SupplierInfo MapCompanyItem(dynamic results)
        {
            var compInfo = new SupplierInfo(results[0].SupplierId, results[0].SupplierName);

            return compInfo;
        }

        private static IEnumerable<SupplierInfo> MapItemList(List<PSupplier> lstObj)
        {

            var lstResult = from item in lstObj
                          select new SupplierInfo(item.SupplierId)
                              {
                                  partyId = item.SupplierId,
                                  partyName = item.SupplierName,
                                  
                              };

            return lstResult;
        }

        Task<SupplierInfo> IQueryRepository<SupplierInfo>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<SupplierInfo>> IQueryRepository<SupplierInfo>.GetList(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
