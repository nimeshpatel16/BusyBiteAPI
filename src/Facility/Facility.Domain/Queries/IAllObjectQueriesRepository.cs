using Envision.MDM.Location.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Location.Domain.AggregatesModel
{
    public interface IAllCompanyQueriesRepository: IQueryRepository<CompanyInfo>
    {
        //Task<IEnumerable<CompanyInfo>> GetAllCompanyAsync(string CompanyName);
       
    }

    public interface IAllSupplierQueriesRepository : IQueryRepository<SupplierInfo>
    {
        //Task<IEnumerable<CompanyInfo>> GetAllCompanyAsync(string CompanyName);

    }

    public interface IAllAgentQueriesRepository : IQueryRepository<AgentInfo>
    {
        //Task<IEnumerable<CompanyInfo>> GetAllCompanyAsync(string CompanyName);

    }

    public interface IAllUserQueriesRepository 
    {
        Task<UserInfo> GetUserDetail(string UserName, string Password);

    }
}
