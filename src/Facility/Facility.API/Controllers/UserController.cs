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
    public class UserController : HomeController
    {
        private readonly IUserService _objIService;

        /// <summary>
        /// Main class constructor. We will inject a instance of the IService Interface
        /// </summary>
        /// <param name="facilityQueryRepository"></param>
        public UserController(IUserService objService)
        {
            _objIService = objService ?? throw new ArgumentException(nameof(objService));
        }

        public new class  User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };
        [HttpPost]
        [Route("Authenticate", Name = "Authenticate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Authenticate(string username, string password)
        {
            try
            {
                var facilities = await _objIService.GetUserDetail(username,password);
                return Ok(facilities);
               // var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

               // //return null if user not found
               // if (user == null)
               //     return null;

               //// authentication successful so return user details without password
               // user.Password = null;
               // return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error has occured. Please contact your Administrator");
            }
        }



    }
}
