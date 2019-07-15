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

        public async Task<OutStandingSummary> GetByIdAsync(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                

                var result = await connection.QueryAsync<POutStandingSummary>("[dbo].[SPSalesOutstanding_NP]",
                    param, commandType: CommandType.StoredProcedure);

                if (result.AsList().Count == 0)
                {
                    throw new KeyNotFoundException();
                }

                return MapOutStandingItem(result);
            }
        }


        public async Task<IEnumerable<OutStandingSummary>> GetOutstandingList(RequestOutStandingSummary objOutStanding)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    var param = new DynamicParameters();
                    param.Add("@CCode", objOutStanding.companyId==-1? 0: objOutStanding.companyId, DbType.Int32);
                    param.Add("@D1", objOutStanding.date1, DbType.Date);
                    param.Add("@D2", objOutStanding.date2, DbType.Date);
                    param.Add("@SCode", objOutStanding.partyId ==-1?0 : objOutStanding.partyId, DbType.Int32);
                    param.Add("@AgCode", objOutStanding.agentId==-1 ? 0 :objOutStanding.agentId, DbType.Int32);

                    var result = await connection.QueryAsync<POutStandingSummary>("[dbo].[SPONLINESalesOutstandingSummary]",
                        param, commandType: CommandType.StoredProcedure,commandTimeout:0);


                    return MapOutStandingItemList(result.AsList());
                }
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
                       
        }

        public async Task<IEnumerable<OutStandingDetail>> GetOutstandingListByParty(RequestOutStandingDetail objOutStanding)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var param = new DynamicParameters();
                    param.Add("@CCode", objOutStanding.companyId==-1? 0 : objOutStanding.companyId, DbType.Int32);
                    param.Add("@D1", objOutStanding.date1, DbType.Date);
                    param.Add("@D2", objOutStanding.date2, DbType.Date);
                    param.Add("@CityName", string.Empty, DbType.String);
                    param.Add("@SCode", objOutStanding.partyId==-1 ? 0 : objOutStanding.partyId, DbType.Int32);
                    param.Add("@AgCode", objOutStanding.agentId==-1 ? 0 : objOutStanding.agentId, DbType.Int32);
                    param.Add("@PaidUnPaid", 0, DbType.Int32);
                    param.Add("@Option", 0, DbType.Int32);


                    var result = await connection.QueryAsync<POutStandingDetail>("[dbo].[SPONLINESalesOutstandingDetail]",
                        param, commandType: CommandType.StoredProcedure, commandTimeout: 0);


                    return MapOutStandingItemListByParty(result.AsList());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public Task<IEnumerable<OutStandingSummary>> GetList(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<FinancialYear> GetFinancialYear()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var param = new DynamicParameters();
      
                    var result = await connection.QueryAsync<PFinancialYear>("[dbo].[usp_GetFinYear]",
                        param, commandType: CommandType.StoredProcedure);


                    return MapFinYear(result.AsList());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static OutStandingSummary MapOutStandingItem(dynamic results)
        {
            
            var outStanding = new OutStandingSummary();
            outStanding.agentId = results[0].Id;
            return outStanding;
        }

        private static FinancialYear MapFinYear(dynamic results)
        {

            var finYear = new FinancialYear();
            finYear.startDate = results[0].StartDate;
            finYear.endDate = results[0].EndDate;
            return finYear;
        }

        private static IEnumerable<OutStandingSummary> MapOutStandingItemList(List<POutStandingSummary> lstoutStanding)
        {

            var lstoutstanding = from item in lstoutStanding
                                 select new OutStandingSummary()
                                 {
                                     agentId = item.AgentId,
                                     companyId = item.CompanyId,
                                     partyId = item.PartyId,
                                     partyName = item.PartyName,
                                     BillAmount = item.BillAmount,
                                     PaidAmount = item.PaidAmount,
                                     Balance = item.Balance,
                                     startDate=item.StartDate,
                                     endDate=item.EndDate
                                 };

            return lstoutstanding;
        }

        private static IEnumerable<OutStandingDetail> MapOutStandingItemListByParty(List<POutStandingDetail> lstoutStanding)
        {

            var lstoutstanding = from item in lstoutStanding
                                 select new OutStandingDetail()
                                 {
                                     agentId = item.AgentId,
                                     agentName = item.AgentName,
                                     companyId = item.CompanyId,
                                     companyName=item.CompanyName,
                                     partyId = item.PartyId,
                                     partyName = item.PartyName,
                                     BillNo=item.BillNo,
                                     BillDate=item.BillDate,
                                     BillAmount = item.BillAmount,
                                     PaidAmount = item.PaidAmount,
                                     Balance = item.Balance,
                                 };

            return lstoutstanding;
        }
        public Task<IEnumerable<OutStandingSummary>> GetList(string ObjName)
        {
            throw new NotImplementedException();
        }

           }
}
