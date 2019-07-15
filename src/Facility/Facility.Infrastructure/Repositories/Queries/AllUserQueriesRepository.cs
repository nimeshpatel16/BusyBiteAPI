using Dapper;
using Envision.MDM.Location.Domain.AggregatesModel;
using Envision.MDM.Location.Domain.Common;
using Envision.MDM.Location.Infrastructure.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.MDM.Location.Infrastructure.Repositories.Queries
{
    public class AllUserQueriesRepository : IAllUserQueriesRepository
    {

        private readonly string _connectionString = string.Empty;

        public AllUserQueriesRepository(string connString)
        {
            _connectionString = !string.IsNullOrEmpty(connString) ? connString : throw new ArgumentNullException(nameof(connString));
        }

        public async Task<UserInfo> GetUserDetail(string UserName, string Password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();

                param.Add("@UserName", UserName, DbType.String);
                param.Add("@Password", Password, DbType.String);

                var result = await connection.QueryAsync<PUserInfo>("[dbo].[usp_GetUserDetail]",
                    param, commandType: CommandType.StoredProcedure);

                return MapUserItem(result.AsList());

            }

        }


        private static UserInfo MapUserItem(dynamic results)
        {
            var userInfo = new UserInfo(results[0].Id, results[0].FirstName, results[0].LastName, results[0].UserName, results[0].Password);

            return userInfo;
        }

       

    }
}
