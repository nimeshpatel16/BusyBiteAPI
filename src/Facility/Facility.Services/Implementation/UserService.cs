using Envision.MDM.Facility.Service.Interfaces;
using Envision.MDM.Location.Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Envision.MDM.Facility.Service
{
    public class UserService : IUserService
    {
        private readonly IAllUserQueriesRepository _AllObjQueryRepository;

        public UserService(IAllUserQueriesRepository AllObjQueryRepository)
        {
            _AllObjQueryRepository = AllObjQueryRepository ?? throw new ArgumentException(nameof(AllObjQueryRepository));

        }

        public Task<UserInfo> GetUserDetail(string UserName, string Password)
        {
            var facility = _AllObjQueryRepository.GetUserDetail(UserName, Password);

            return facility;
        }
    }
}
