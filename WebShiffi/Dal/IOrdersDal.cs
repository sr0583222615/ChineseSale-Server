using webApi.models;
using WebShiffi.models;

namespace WebShiffi.DAL
{
    public interface IOrdersDal
    {

        public Task<List<Gift>> getOrders(User middlewareUser);
        public Task<List<Orders>> getById(int id);//צפיה ברכישת כרטיסים עבור כל מתנה

        public Task<List<Gift>> add(Gift gift, User middlewareUser);

        public Task<int> delete(int id, User middlewareUser );
        public Task<int> Put(Gift[] arr,User middlewareUser);

        //public  Task<List<Orders>> listItems();
        public Task<List<Gift>> orderByBest();
        public  Task<List<OrderItems>> listItems();//פרטי רוכשים


    }
}

//public async Task<IEnumerable<OrderItem>> GetGiftCardsAsync(string giftName)
//{
//    var giftId = _productDal.SearchGiftsDal(giftName, null, null).Result.First().ProductId;
//    return await _payingContext.OrderItem.Where(o => o.ProductId == giftId).ToListAsync();
//}

//public async Task<IEnumerable<Product>> GetSortGiftsAsync(bool? price, bool? maxQuentity)
//{
//    if (price.HasValue)
//    {
//        return await _payingContext.Products.OrderBy(g => g.Price).ToListAsync();
//    }
//    else if (maxQuentity.HasValue)
//    {
//        return await _payingContext.Products
//            .OrderByDescending(product => _payingContext.OrderItem.Count(orderItem => orderItem.ProductId == product.ProductId))
//            .ToListAsync();
//    }
//    else
//    {
//        return null;
//    }
//}

//public async Task<string> GetPurchesesDetailsAsync()
//{
//    var customersWithOrders = await _payingContext.Customer
//        .Where(p => p.Order.Count > 0)
//        .Select(p => $"{p.FirstName} {p.LastName}")
//        .ToListAsync();

//    return string.Join(", ", customersWithOrders);
//}

