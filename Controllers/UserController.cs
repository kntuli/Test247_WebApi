using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test247_WebApi.DataProvider;
using Test247_WebApi.Models;

namespace Test247_WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDataProvider userDataProvider;

        [HttpGet("user")]
        [Produces("application/json")]
        public async Task<IEnumerable<UserModel>> GetUser([FromBody] UserModel _userData)
        {
            return await this.userDataProvider.GetUser(_userData.username, _userData.password);
        }

    }
}