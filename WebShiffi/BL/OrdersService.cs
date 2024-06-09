using webApi.models;
using WebShiffi.DAL;
using WebShiffi.DAL;
using WebShiffi.DTO;
using WebShiffi.models;

namespace WebShiffi.BL
{
    public class OrdersService:IOrdersService

    {
        private readonly IOrdersDal dal;



        public OrdersService(IOrdersDal dalOrders) 
        {
        this.dal = dalOrders??throw new ArgumentNullException(nameof(dalOrders));       
        }
        public  Task<List<Gift>> getOrders(User middlewareUser)
        {
            return dal.getOrders(middlewareUser);
        }

        public  Task<List<Orders>> getById(int id)//צפיה ברכישת כרטיסים עבור כל מתנה
        {
            return  this.dal.getById(id);
        }

        public Task<List<Gift>>add(Gift gift, User middlewareUser)
 { 
           
            return this.dal.add(gift, middlewareUser);
        }
        public Task<int> delete(int id , User middlewareUser)
        {

            return this.dal.delete(id,middlewareUser);
        }

        public Task<int> Put(Gift[] arr,User middlewareUser)
        {
            return this.dal.Put(arr,middlewareUser);
        }

        public Task<List<OrderItems>> listItems()
        { return this.dal.listItems(); }

        public Task<List<Gift>> orderByBest()
        {
            return this.dal.orderByBest();
        }


    }
}
