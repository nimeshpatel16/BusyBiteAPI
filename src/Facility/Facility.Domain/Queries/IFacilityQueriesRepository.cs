using Envision.MDM.Location.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Envision.MDM.Location.Domain.AggregatesModel
{
    public interface IFacilityQueriesRepository:IQueryRepository<Facility>
    {
        Task<IEnumerable<Facility>> GetByLOB(int pageIndex, int pageSize, string lineOfBusiness);
        Task<IEnumerable<Facility>> GetFacilityList(Facility Objfacility);
    }
}
