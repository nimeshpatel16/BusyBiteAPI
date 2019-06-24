using System.Collections.Generic;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service.Interfaces
{
    public interface IFacilityService
    {
        Task<Location.Domain.AggregatesModel.Facility> LoadFacilityById(int id);
        Task<IEnumerable<Location.Domain.AggregatesModel.Facility>> LoadFacilitybyLOB(int pageIndex, int pageSize, string lineOfBusiness);
        Task<IEnumerable<Location.Domain.AggregatesModel.Facility>> RetriveFacilityList(int pageIndex, int pageSize);
        Task<IEnumerable<Location.Domain.AggregatesModel.Facility>> LoadGetFacilityList(Location.Domain.AggregatesModel.Facility ObjFacility);
    }
}
