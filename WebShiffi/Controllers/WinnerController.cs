using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using webApi.models;
using WebShiffi.BL;
using WebShiffi.DAL;
using WebShiffi.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShiffi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnerController : ControllerBase
    {
        private readonly IWinnerService serv;
        public WinnerController(IWinnerService serv)
        {
            this.serv = serv;
        }
    
        // GET: api/<WinnerController>
        [HttpGet]
        public Task<List<Winners>> Get()
        {
            return this.serv.listOfWinners();  
        }

        [HttpGet("allmony")]
        public Task<int> GetSum()
        {
            return this.serv.allMony();
        }
        // GET api/<WinnerController>/5
        [HttpPost("{gift}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Get([FromBody] int gift)
        {
            var res = await serv.raffle(gift); // הנחה: serv.raffle הוא אובייקט שמחזיר Task<string>

            if (res != null)
            {
                //string ress = JsonConvert.SerializeObject(new { res });

                return Ok(new { res });
            }

            return NotFound("not ok");
        }
    }


    //public async Task<ActionResult<string>> Login([FromBody] UserLogin userLogin)
    //{
    //    //logger.LogInformation("in loggin");

    //    var user = await this.userService.Authenticate(userLogin);
    //    if (user != null)
    //    {
    //        object token = this.userService.Generate(user);
    //        string jsonToken = JsonConvert.SerializeObject(new { token });
    //        return Ok(new { jsonToken });
    //    }
    //    return NotFound("UserNot Found");
    //}



    //[HttpGet("email")]
    //    public Task GetEmail() 
    //    {
    //        return this.serv.SendEmailAsync("ros5879320@gmail.com", "you the winner", "winner");

    //    }
    
    //}
}
