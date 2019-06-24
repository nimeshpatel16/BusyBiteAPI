using Dapper;
using Envision.MDM.Location.Infrastructure.Repositories.Queries;
using Moq;
using Moq.Dapper;
using System.Data.Common;
using System.Threading.Tasks;
using Xunit;

namespace Envision.Facility.UnitTests.Infrastructure
{
    public class FacilityQueriesRepositoryTest
    {
        [Fact]
        public async Task GetById_And_Return_Facility_Object_Test()
        {
            var connection = new Mock<DbConnection>();

            var expected = new[] { 7, 77, 777 };

            connection.SetupDapperAsync(c => c.QueryAsync<int>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(expected);

             
            var repository = new FacilityQueriesRepository("Test");

            var result = repository.GetById(555);

        }

    }
}
