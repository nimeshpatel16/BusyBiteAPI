using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Location.Domain.AggregatesModel.CompanyInfo>> GetAllCompany(string CompanyName);
    }
}
