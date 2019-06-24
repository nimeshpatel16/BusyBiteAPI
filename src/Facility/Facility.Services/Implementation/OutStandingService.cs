using System;
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

        public Task<Location.Domain.AggregatesModel.OutStanding> LoadOutStandingById(int id)
        {
            var outstanding = _outStandingQueryRepository.GetById(id);

            return outstanding;
        }
    }
}
