using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using webApi.models;
using WebShiffi.Bal;
using WebShiffi.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//אולי צריך להוצאי את הasync await  לא ברור למה שמתי , לא עבד בלי...

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
        [HttpGet]
        public  async Task<ActionResult<List<Gift>>> Get()
        {
            var list= await this.giftService.GetGifts();
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gift>> GetByName(int id)
        {
            var gift=await this.giftService.Getidbal(id);
            if (gift != null)
            {
                return Ok(gift);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<List<Gift>>> addGift(Gift g)
        {
            var list=await this.giftService.addGift(g);
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost("addDonation")]
        public async Task<ActionResult<Donation>> addDonation(Donation d)//add_donation
        {
            var donation = await this.giftService.addDonation(d);
            if (donation != null)
            {
                return Ok(donation);
            }
            return NotFound();

        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<int>>  Put(int id, [FromBody]Gift  gift )
        {
            var num= await this.giftService.update(id, gift);
            if (num != null)
            {
                return Ok(num);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public  ActionResult<int> DeleteId(int id)/////ללא task
        {
           var num= this.giftService.deleteGift(id);
            if (num != null)
            {
                return Ok(num);
            }
            return NotFound();
        }

        [HttpGet("findByName{name}")]
        public async Task<ActionResult<Gift>> GetByName(string name)
        {
            var gift=await this.giftService.FilerName(name);
            if (gift != null)
            {
                return Ok(gift);
            }
            return NotFound();
        }

        [HttpGet("FindByDonor{donorName}")]
        public async Task<ActionResult<List<Gift>>> Get(string donorName)
        {
            var list=await this.giftService.FilerDonor(donorName);
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }


        [HttpGet("FindByCategory{category}")]
        public async Task<ActionResult<List<Gift>>> GetByCategory(string category)
        {
            var list=await this.giftService.FillterCategory(category);
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }


        [HttpGet("Cost{price}")]
        public async Task<ActionResult<List<Gift>>> GetByPrice(int price)
        {
            var list= await this.giftService.FillterPrice(price);
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }

        [HttpGet("CostBYorder")]
        public async Task<ActionResult<List<Gift>>> GetByCheeper()
        {
            var list=await this.giftService.FillterByPriceLow();
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }
        [HttpGet("CostByExpensive")]
        public async Task<ActionResult<List<Gift>>> GetByExpensive()
        {
            var list=await this.giftService.FillterByPriceHighe();
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }
        [HttpGet("FilterByOrders{n}")]

        public async Task<ActionResult<List<Gift>>> FillterByOrders(int n)//filter by orders
        {
            var list=await this.giftService.FillterByOrders(n);
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }



    }
}
