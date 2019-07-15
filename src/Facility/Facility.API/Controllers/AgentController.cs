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
    public class AgentController : HomeController
    {
        private readonly IAgentService _objIService;

        /// <summary>
        /// Main class constructor. We will inject a instance of the IService Interface
        /// </summary>
        /// <param name="facilityQueryRepository"></param>
        public AgentController(IAgentService objService)
        {
            _objIService = objService ?? throw new ArgumentException(nameof(objService));
        }

        class customer{

            public int CompanyId { get; set; }
            public string CompanyName { get; set; }
            public int Id { get; set; }
            public string DomainEvents { get; set; }
        }
       

        [HttpGet("{AgentName}", Name = "GetAllAgentOrById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetAllAgentOrById(string AgentName)
        {
            try
            {
                //List<customer> obj = new List<customer>();
                //obj.Add(new customer { CompanyId = 1, CompanyName = "BB" });
                //obj.Add(new customer { CompanyId = 2, CompanyName = " Busy Byte" });

               // var outStanding = obj;
                var outStanding = await _objIService.GetAllAgent(AgentName);
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
