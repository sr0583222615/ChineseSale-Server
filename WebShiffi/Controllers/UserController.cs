using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webApi.Dal;
using webApi.models;
using WebShiffi.BL;
using WebShiffi.models;
using Microsoft.Extensions.Logging;
using WebShiffi.Bal;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShiffi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserService userService;
        public UserController(IUserService userService, ILogger<UserController> _logger)
        {
            this.logger = _logger ?? throw new ArgumentNullException(nameof(logger));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLogin userLogin)
        {
            var user = await this.userService.Authenticate(userLogin);
            if (user != null)
            {
                object token = this.userService.Generate(user);
                string jsonToken = JsonConvert.SerializeObject(new { token });
                return Ok( new { jsonToken });
            }
            return NotFound("UserNot Found");
        }
        [HttpPost]
        public Task<int> register(User user)
        {
            return  this.userService.add(user); 
        }
    }
}
