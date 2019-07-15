using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Envision.MDM.Facility.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Envision.MDM.Location.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SupplierController : HomeController
    {
        private readonly ISupplierService _objIService;

        /// <summary>
        /// Main class constructor. We will inject a instance of the IService Interface
        /// </summary>
        /// <param name="facilityQueryRepository"></param>
        public SupplierController(ISupplierService objService)
        {
            _objIService = objService ?? throw new ArgumentException(nameof(objService));
        }

       

        [HttpGet("{SupplierName}", Name = "GetAllSupplier")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetAllSupplier(string SupplierName)
        {
            try
            {
                var outStanding = await _objIService.GetAllSupplier(SupplierName);
                return Ok(outStanding.ToList());
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


    }
}
