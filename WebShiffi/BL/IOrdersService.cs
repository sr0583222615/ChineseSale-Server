using webApi.models;
using WebShiffi.models;

namespace WebShiffi.BL
{
    public interface IOrdersService
    {
        public Task<List<Gift>> getOrders(User middlewareUser);
        public Task<List<Orders>> getById(int id);//צפיה ברכישת כרטיסים עבור כל מתנה


        public Task<List<Gift>> add(Gift gift , User middlewareUser);
        public Task<int> delete(int id, User middlewareUser);
        public Task<int> Put(Gift[] arr,User middlewareUser);
        public Task<List<OrderItems>> listItems();
        public Task<List<Gift>> orderByBest();


    }
}
