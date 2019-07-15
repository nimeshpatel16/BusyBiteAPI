
using Envision.MDM.Location.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Location.Domain.AggregatesModel
{
    public interface IOutStandingQueriesRepository : IQueryRepository<OutStandingSummary>
    {
        //int CompanyId,DateTime date1,DateTime date2, int SupplierCode, int AgentCode

        Task<IEnumerable<OutStandingSummary>> GetOutstandingList(RequestOutStandingSummary objOutStanding);
        Task<IEnumerable<OutStandingDetail>> GetOutstandingListByParty(RequestOutStandingDetail objOutStanding);
        Task<FinancialYear> GetFinancialYear();
    }
}
