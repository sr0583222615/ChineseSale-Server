using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webApi.models;
using WebShiffi.Bal;
using WebShiffi.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShiffi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorService IdonorSer;
        public DonorsController(IDonorService idonorService)
        {
            IdonorSer = idonorService ?? throw new ArgumentNullException(nameof(idonorService));
        }
        [HttpGet]
        public Task<List<Donors>> Get()
        {
            return this.IdonorSer.GetDonors();
        }
       
        // POST api/<DonorsController>
        [HttpPost("add")]
        public  ActionResult<int> Post([FromBody] Donors d)
        {
           var num= this.IdonorSer.addDonor(d);
            if (num != null)
            {
                return Ok(num);
            }
            return NotFound();
        }
                                                    
        // PUT api/<DonorsController>/5
        [HttpPut("{id}")]
        public ActionResult<Donors> Put(string id, [FromBody] Donors d)
        {
            var donor= this.IdonorSer.update(id, d);
            if (donor != null)
            {
                return Ok(donor);
            }
            return NotFound();
        }

        // DELETE api/<DonorsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> deleteOne(string id)//delete
        {
            var num= await this.IdonorSer.delete(id);
            if (num != null)
            {
                return Ok(num);
            }
            return NotFound();
        }

        [HttpGet("ByDonotion{id}")]
        
        public Task<List<Donors>> GetDonation(string id)
        {
            return this.IdonorSer.GetDonation(id);
 
        }
       

      
        // GET api/<DonorsController>/5
        [HttpGet("name{id}")]
        public Task<Donors> Get(string id)//filter by name
        {
           return this.IdonorSer.GetId(id);

        }


    }
}
