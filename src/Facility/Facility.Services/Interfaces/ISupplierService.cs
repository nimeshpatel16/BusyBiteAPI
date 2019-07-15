using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Location.Domain.AggregatesModel.SupplierInfo>> GetAllSupplier(string SupplierName);
    }
}
