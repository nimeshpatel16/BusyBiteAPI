using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service.Interfaces
{
    public interface IUserService
    {
        Task<Location.Domain.AggregatesModel.UserInfo> GetUserDetail(string UserName, string Password);
    }
}
