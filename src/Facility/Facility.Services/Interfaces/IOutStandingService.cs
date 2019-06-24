using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service.Interfaces
{
    public interface IOutStandingService
    {
        Task<Location.Domain.AggregatesModel.OutStanding> LoadOutStandingById(int id);
    }
}
