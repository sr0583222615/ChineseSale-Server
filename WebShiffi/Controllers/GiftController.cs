using Microsoft.AspNetCore.Mvc;
using webApi.models;
using WebShiffi.Bal;
using WebShiffi.Migrations;
using WebShiffi.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShiffi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class GiftController : ControllerBase
    {


        private readonly IGiftService giftService;

        public GiftController(IGiftService giftSer)
        {
            this.giftService= giftSer ?? throw new ArgumentNullException(nameof(giftService));
        }
        // GET: api/<GiftController>
        [HttpGet]
        public async Task<ActionResult<List<object>>> Get()
        {
            return await this.giftService.GetGifts();
        }

        // GET api/<GiftController>/5
        [HttpGet("{id}")]
        public Task<object> Get(int id)
        {
            return this.giftService.Getidbal(id);
        }

        // POST api/<GiftController>
        [HttpPost]
        public Task<Gift> addGift( Gift g)
        {
            return this.giftService.addGift(g);

        }
        [HttpPost("addDonation")]
        public Task<Donation> addDonation(Donation d)
        {
            return this.giftService.addDonation(d);

        }

        // PUT api/<GiftController>/5
        [HttpPut("{id}")]
        public Task<Gift>  Put(int id, [FromBody]Gift  gift )
        {

            return this.giftService.update(id, gift);


        }

        // DELETE api/<GiftController>/5
        [HttpDelete("{id}")]
        public int DeleteId(int id)
        {
           return this.giftService.deleteGift(id);

        }
        [HttpDelete("Delete")]
        public void Delete(int id)
        {


        }

        [HttpGet("findByName")]
        //public Task<Gift> Get(string name)
        //{
        //    return this.giftService.FilerName(name);
        //}

        [HttpGet("FindByDonor")]
        public Task<List<Gift>> Get(string donorName)
        {
            return this.giftService.FilerDonor(donorName);
        }
    }
}
