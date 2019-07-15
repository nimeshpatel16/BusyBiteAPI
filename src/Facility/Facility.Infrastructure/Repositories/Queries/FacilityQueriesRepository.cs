
using Dapper;
using Envision.MDM.Location.Domain.AggregatesModel;
using Envision.MDM.Location.Domain.Common;
using Envision.MDM.Location.Infrastructure.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Envision.MDM.Location.Infrastructure.Repositories.Queries
{
    public class FacilityQueriesRepository 
        : IFacilityQueriesRepository
    {
        private readonly string  _connectionString = string.Empty;

        public FacilityQueriesRepository(string connString)
        {
            _connectionString = !string.IsNullOrEmpty(connString) ? connString : throw new ArgumentNullException(nameof(connString));
        }

        public IUnitofWork UnitofWork => throw new NotImplementedException();

        /// <summary>
        /// This method will return a list of all Facilities from the DB
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="lineOfBusiness"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Facility>> GetList(int pageIndex, int pageSize)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
              
                connection.Open();

                var result = await connection.QueryAsync<PFacility>("usp_iqGetMDMFacility", CommandType.StoredProcedure);
   
                return MapFacilityItemList(result.AsList());               
            }
        }
        public async Task<IEnumerable<Facility>> GetFacilityList(Facility objFacility)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@SortField", objFacility.SortbyColumn, DbType.String);
                param.Add("@SortDirection", objFacility.SortDirection, DbType.String);
                param.Add("@PageIndex", objFacility.PageIndex, DbType.Int32);
                param.Add("@FacilityId", objFacility.FacilityID, DbType.Int32);
                param.Add("@PageSize", objFacility.PageSize, DbType.Int32);
                param.Add("@Division", null, DbType.String);
                param.Add("@Code", objFacility.Code, DbType.String);
                param.Add("@LegalName", objFacility.LegalName, DbType.String);
                param.Add("@LegalEntityName", null, DbType.String);
                param.Add("@EDWCode", null, DbType.String);
                param.Add("@Name", objFacility.Name, DbType.String);
                param.Add("@IsActive", null, DbType.String);
                param.Add("@EdiCode", null, DbType.String);
                param.Add("@RegistryId", null, DbType.String);
                param.Add("@LegalEntityId", null, DbType.Int32);
                param.Add("@ExternalSystemId", null, DbType.Int32);

                var result = await connection.QueryAsync<PFacility>("usp_iqGetMDMFacility",
                    param, commandType: CommandType.StoredProcedure);

                if (!result.Any())
                {
                    throw new KeyNotFoundException();
                }

                return MapFacilityItemList(result.AsList());
            }
        }
        /// <summary>
        /// This method executes a store procedure to get a single record set for a particular facility
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Facility> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@FacilityID", id, DbType.Int32);

                var result = await connection.QueryAsync<dynamic>("usp_iqGetMDMFacilityDetailsByID", 
                    param, commandType: CommandType.StoredProcedure);

                if (result.AsList().Count == 0)
                {
                    throw new KeyNotFoundException();
                }

                return MapFacilityItem(result);
            }
        }


        public async Task<IEnumerable<Facility>> GetByLOB(int pageIndex, int pageSize, string lineOfBusiness)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var param = new DynamicParameters();
                param.Add("@LOB", lineOfBusiness, DbType.String);

                var result = await connection.QueryAsync<PFacility>("iqGetMDMFacilityByLOB",
                    param, commandType: CommandType.StoredProcedure);

                if (!result.Any())
                {
                    throw new KeyNotFoundException();
                }

                return MapFacilityItemList(result.AsList());
            }
        }


        /// <summary>
        /// This method will map a dynamic result to a single instance of a facility
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private static Facility MapFacilityItem(dynamic results)
        {
            var address = new Address(results[0].Address1, results[0].City,
                results[0].State, string.Empty, results[0].ZipCode);

            var facility = new Facility(results[0].FacilityId, results[0].Name, results[0].Code, results[0].LegalName, results[0].FacilityLegalName);

            facility.AddNewAddess(address);
            
            return facility;
        }

        /// <summary>
        /// This method will map the POCO object to the Facility domain objects
        /// </summary>
        /// <param name="lstFacility"></param>
        /// <returns></returns>
        private static IEnumerable<Facility> MapFacilityItemList(List<PFacility> lstFacility)
        {

            var lstfacility = from item in lstFacility
                              select new Facility(item.FacilityID)
                              {
                                  Name = item.Name,
                                  Code = item.Code,
                                  LegalName = item.Name,
                                  Address = new Address()
                                  {
                                      Street = item.Address1,
                                      City = item.City,
                                      State = item.State,
                                      ZipCode  = item.ZipCode, 
                                      Country = string.Empty
                                  }
                              };

            return lstfacility;
        }

        public Task<IEnumerable<Facility>> GetList(string ObjName)
        {
            throw new NotImplementedException();
        }
    }
}
