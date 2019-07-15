using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Envision.MDM.Facility.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Envision.MDM.Location.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OustandingController : HomeController
    {
        private readonly IOutStandingService _outStandingService;

        /// <summary>
        /// Main class constructor. We will inject a instance of the IService Interface
        /// </summary>
        /// <param name="facilityQueryRepository"></param>
        public OustandingController(IOutStandingService outStandingService)
        {
            _outStandingService = outStandingService ?? throw new ArgumentException(nameof(outStandingService));
        }

       

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var outStanding = await _outStandingService.LoadOutStandingById(id);
                return Ok(outStanding);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error has occured. Please contact your Administrator");
            }
        }

       // [HttpPost(Name = "AllOutStandingList")]
        [HttpPost]
        [Route("OutStandingList", Name = "AllOutStandingList")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> AllOutStandingList(Domain.AggregatesModel.RequestOutStandingSummary objOutStanding)
        {
            try
            {
                var facilities = await _outStandingService.LoadOutStandingList(objOutStanding);
                return Ok(facilities);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error has occured. Please contact your Administrator");
            }
        }

        [HttpPost]
        [Route("OutStandingByParty",Name = "AllOutStandingListByParty")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> AllOutStandingListByParty(Domain.AggregatesModel.RequestOutStandingDetail objOutStanding)
        {
            try
            {
                var facilities = await _outStandingService.LoadOutStandingListByParty(objOutStanding);
                return Ok(facilities);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error has occured. Please contact your Administrator");
            }
        }

        [HttpGet]
        [Route("FinYear", Name = "GetFinYear")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetFinYear()
        {
            try
            {
                var facilities = await _outStandingService.GetFinancialYear();
                return Ok(facilities);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error has occured. Please contact your Administrator");
            }
        }
    }
}
