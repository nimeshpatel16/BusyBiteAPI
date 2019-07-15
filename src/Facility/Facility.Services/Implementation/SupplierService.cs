using Envision.MDM.Facility.Service.Interfaces;
using Envision.MDM.Location.Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly IAllSupplierQueriesRepository _AllObjQueryRepository;

        public SupplierService(IAllSupplierQueriesRepository AllObjQueryRepository)
        {
            _AllObjQueryRepository = AllObjQueryRepository ?? throw new ArgumentException(nameof(AllObjQueryRepository));

        }

        public Task<IEnumerable<SupplierInfo>> GetAllSupplier(string SupplierName)
        {
            var facility = _AllObjQueryRepository.GetList(SupplierName);

            return facility;
        }
    }
}
