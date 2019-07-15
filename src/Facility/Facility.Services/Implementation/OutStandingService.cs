using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Envision.MDM.Facility.Service.Interfaces;
using Envision.MDM.Location.Domain.AggregatesModel;


namespace Envision.MDM.Facility.Service
{
    public class OutStandingService : IOutStandingService
    {
        private readonly IOutStandingQueriesRepository _outStandingQueryRepository;

        public OutStandingService(IOutStandingQueriesRepository outStandingQueryRepository)
        {
            _outStandingQueryRepository = outStandingQueryRepository ?? throw new ArgumentException(nameof(outStandingQueryRepository));

        }

        public Task<Location.Domain.AggregatesModel.OutStandingSummary> LoadOutStandingById(int id)
        {
            var outstanding = _outStandingQueryRepository.GetByIdAsync(id);

            return outstanding;
        }

        public Task<IEnumerable<OutStandingSummary>> LoadOutStandingList(RequestOutStandingSummary objRequest)
        {
            var outstanding = _outStandingQueryRepository.GetOutstandingList(objRequest);

            return outstanding;
        }

        public Task<IEnumerable<OutStandingDetail>> LoadOutStandingListByParty(RequestOutStandingDetail objRequest)
        {
            var outstanding = _outStandingQueryRepository.GetOutstandingListByParty(objRequest);

            return outstanding;
        }

        public Task<FinancialYear> GetFinancialYear()
        {
            var outstanding = _outStandingQueryRepository.GetFinancialYear();
            return outstanding;
        }
    }
}
