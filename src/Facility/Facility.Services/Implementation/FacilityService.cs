using Envision.MDM.Facility.Service.Interfaces;
using Envision.MDM.Location.Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service
{
    public class FacilityService : IFacilityService
    {
        private readonly IFacilityQueriesRepository _facilityQueryRepository;

        public FacilityService(IFacilityQueriesRepository facilityQueryRepository)
        {
            _facilityQueryRepository = facilityQueryRepository ?? throw new ArgumentException(nameof(facilityQueryRepository));

        }

        public Task<Location.Domain.AggregatesModel.Facility> LoadFacilityById(int id)
        {
            var facility = _facilityQueryRepository.GetById(id);

            return facility;
        }
        public Task<IEnumerable<Location.Domain.AggregatesModel.Facility>> LoadGetFacilityList(Location.Domain.AggregatesModel.Facility objfacility)
        {
            var facilityList = _facilityQueryRepository.GetFacilityList(objfacility);
            return facilityList;

        }
        public Task<IEnumerable<Location.Domain.AggregatesModel.Facility>> LoadFacilitybyLOB(int pageIndex, int pageSize, string lineOfBusiness)
        {
            var facilityList = _facilityQueryRepository.GetByLOB(pageIndex, pageSize, lineOfBusiness);
            return facilityList;
            
        }

        public Task<IEnumerable<Location.Domain.AggregatesModel.Facility>> RetriveFacilityList(int pageIndex, int pageSize)
        {
            var facilityList = _facilityQueryRepository.GetList(pageIndex, pageSize);
            return facilityList;
        }
    }
}
