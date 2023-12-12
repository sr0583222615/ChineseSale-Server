using Microsoft.AspNetCore.Mvc;
using webApi.models;
using WebShiffi.Bal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShiffi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorService IdonorSer;
        public DonorsController(IDonorService idonorService)
        {
            IdonorSer = idonorService?? throw new ArgumentNullException(nameof(idonorService)); 
        }
        // GET: api/<DonorsController>
        [HttpGet]
        public Task<List<Donors>> Get()
        {
            return this.IdonorSer.GetDonors();
        }

        // GET api/<DonorsController>/5
        [HttpGet("{id}")]
        public Task<Donors> Get(string id)
        {
            return this.IdonorSer.GetId(id);
        }

        // POST api/<DonorsController>
        [HttpPost]
        public Task<Donors> Post([FromBody] Donors d)
        {
           return this.IdonorSer.addDonor(d);
        }

        // PUT api/<DonorsController>/5
        [HttpPut("{id}")]
        public Task<Donors> Put(string id, [FromBody] Donors d)
        {
            return this.IdonorSer.update(id, d);
        }

        // DELETE api/<DonorsController>/5
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
          return  this.IdonorSer.delete(id);
        }
    }
}
