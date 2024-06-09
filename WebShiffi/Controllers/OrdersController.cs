using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using webApi.models;
using WebShiffi.BL;
using WebShiffi.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShiffi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService serv;
        public OrdersController(IOrdersService serv)
        {
            this.serv = serv?? throw new ArgumentNullException(nameof(serv));
        }
        // get busket
        [HttpGet]
        public async Task<ActionResult<List<Gift>>> GetOrders()
        {
            var middlewareUser = HttpContext.Items["User"] as User;
            if (middlewareUser == null)
            {
                return NotFound("There is no token");
            }
            var orders = await this.serv.getOrders(middlewareUser);
            return Ok(orders);
        }
    
        // add to card
        [HttpPost]
        public async Task<ActionResult<List<Gift>>> Add([FromBody] Gift gift)
        {
            var middlewareUser = HttpContext.Items["User"] as User;
            if (middlewareUser.UserId == null)
            {
                return NotFound();  
            }
            var list = await this.serv.add(gift, middlewareUser);
            if (list == null || list.Count == 0)
            {
                return Ok(new List<Gift>()); // או תחזיר רשימה ריקה בתוך ActionResult
            }
            return Ok(list);
        }
        //buy
        [HttpPut("update")]
        public async Task<ActionResult<int>> Put(Gift [] arr)
        {
            var middlewareUser = HttpContext.Items["User"] as User;
            if (middlewareUser == null)
            {
                return NotFound();
            }
            var num = await this.serv.Put(arr, middlewareUser);
            return Ok(num);

        }
        // delete from the card
        [HttpDelete("{id}")]

        public async Task<ActionResult<int>> Delete(int id)
        {
            var middlewareUser = HttpContext.Items["User"] as User;
            if (middlewareUser == null)
            {
                return NotFound();
            }
            var num= await this.serv.delete(id, middlewareUser);
            if (num != null)
            {
                return Ok(num);
            }
            return NotFound();
        }
        ///detailes of the orders' people
        [HttpGet("BuyerDetails")]
        public async Task<ActionResult<List<OrderItems>>> listItems()
        {
            var list= await this.serv.listItems();
            if(list!=null)
            {
                return Ok(list);

            }
            return NotFound("not found");
        }
        [HttpGet("OrderByTheBest")]
        public  async Task<ActionResult<List<Gift>>> list()
        {
            var list= await this.serv.orderByBest();
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Orders>>> getById(int id)//צפיה ברכישת כרטיסים עבור כל מתנה
        {
            var list=await this.serv.getById(id);
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }


    }
}
