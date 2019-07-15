using Envision.MDM.Facility.Service.Interfaces;
using Envision.MDM.Location.Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IAllCompanyQueriesRepository _AllObjQueryRepository;

        public CompanyService(IAllCompanyQueriesRepository AllObjQueryRepository)
        {
            _AllObjQueryRepository = AllObjQueryRepository ?? throw new ArgumentException(nameof(AllObjQueryRepository));

        }

        public Task<IEnumerable<CompanyInfo>> GetAllCompany(string CompanyName)
        {
            var facility = _AllObjQueryRepository.GetList(CompanyName);

            return facility;
        }

           }
}
