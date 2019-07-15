using Envision.MDM.Facility.Service.Interfaces;
using Envision.MDM.Location.Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service
{
    public class AgentService : IAgentService
    {
        private readonly IAllAgentQueriesRepository _AllObjQueryRepository;

        public AgentService(IAllAgentQueriesRepository AllObjQueryRepository)
        {
            _AllObjQueryRepository = AllObjQueryRepository ?? throw new ArgumentException(nameof(AllObjQueryRepository));

        }

        public Task<IEnumerable<AgentInfo>> GetAllAgent(string AgentName)
        {
            var facility = _AllObjQueryRepository.GetList(AgentName);

            return facility;
        }

       
    }
}
