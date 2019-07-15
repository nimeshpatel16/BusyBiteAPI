using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service.Interfaces
{
    public interface IOutStandingService
    {
        Task<Location.Domain.AggregatesModel.OutStandingSummary> LoadOutStandingById(int id);
        Task<Location.Domain.AggregatesModel.FinancialYear> GetFinancialYear();
        Task<IEnumerable<Location.Domain.AggregatesModel.OutStandingSummary>> LoadOutStandingList(Location.Domain.AggregatesModel.RequestOutStandingSummary objRequest);
        Task<IEnumerable<Location.Domain.AggregatesModel.OutStandingDetail>> LoadOutStandingListByParty(Location.Domain.AggregatesModel.RequestOutStandingDetail objRequest);
    }
}
