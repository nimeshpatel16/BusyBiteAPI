using Envision.MDM.Facility.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Envision.MDM.Location.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FacilityController : HomeController
    {
        private readonly IFacilityService _facilityService;

        /// <summary>
        /// Main class constructor. We will inject a instance of the IService Interface
        /// </summary>
        /// <param name="facilityQueryRepository"></param>
        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService ?? throw new ArgumentException(nameof(facilityService));
        }

        /// <summary>
        /// This method will return a single facility if the id exists on the DB
        /// </summary>
        /// <param name="facilityid"></param>
        /// <returns></returns>
        //[HttpGet("{facilityid}", Name = "GetById")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //public async Task<ActionResult> GetById(int facilityid)
        //{
        //    try
        //    {
        //        var facility = await _facilityService.LoadFacilityById(facilityid);
        //        return Ok(facility);
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        return NotFound();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error has occured. Please contact your Administrator");
        //    }
        //}
        /// <summary>
        /// This method will return a list of facility based on filter criteria
        /// </summary>
        /// <param name="Objfacility"></param>
        /// <returns></returns>
        /// 

        [HttpPost(Name = "AllFacilityList")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetAllFacilityList(Domain.AggregatesModel.Facility Objfacility)
        {
            try
            {
                var facilities = await _facilityService.LoadGetFacilityList(Objfacility);
                return Ok(facilities);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error has occured. Please contact your Administrator");
            }
        }
        /// <summary>
        /// This method will return a list of facility based on the specific page side and page index
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("{pageIndex}, {pageSize}", Name = "Get")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Get(int pageIndex, int pageSize)
        {
            try
            {
                var facilities = await _facilityService.RetriveFacilityList(pageIndex, pageSize);
                return Ok(facilities);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error has occured. Please contact your Administrator");
            }
        }

        /// <summary>
        /// This method will return a list of facility based on the specific page side and page index
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Pass LOB"></param>
        /// <returns></returns>
        [HttpGet("{pageIndex},{pageSize},{lineOfBusiness}", Name = "GetByLOB")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetByLOB(int pageIndex, int pageSize, string lineOfBusiness)
        {
            try
            {
                var facilities = await _facilityService.LoadFacilitybyLOB(pageIndex, pageSize, lineOfBusiness);
                return Ok(facilities);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error has occured. Please contact your Administrator");
            }
        }

    }
}
