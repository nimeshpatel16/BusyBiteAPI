using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service.Interfaces
{
    public interface IAgentService
    {
        Task<IEnumerable<Location.Domain.AggregatesModel.AgentInfo>> GetAllAgent(string AgentName);
    }
}
