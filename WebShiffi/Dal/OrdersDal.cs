using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using webApi.Dal;
using webApi.models;
using WebShiffi.DTO;
using WebShiffi.models;

namespace WebShiffi.DAL
{
    public class OrdersDal:IOrdersDal
       
    {
        private readonly ChineseSaleContext context;
        private readonly IMapper mapper;
        int x = 500;


        public OrdersDal(ChineseSaleContext _ChineseSaleContext, IMapper map)
        {
            this.context = _ChineseSaleContext?? throw new ArgumentNullException(nameof(context)); 
            this.mapper = map;
        }

        public async Task<List<Gift>> getOrders(User middlewareUser)
        {
            try
            {
                var orders = await this.context.Orders
                               .Where(o => o.UsersId == middlewareUser.UserId && o.Status == "chart")
                               .Include(a => a.Gift)
                               .ToListAsync();

                if (orders.Any())
                {
                    var gifts = orders.Select(o => o.Gift).ToList();
                    var giftsWithDonors = new List<Gift>();

                    foreach (var gift in gifts)
                    {
                        var donors = this.context.Donation
                            .Where(d => d.Gift.GiftId == gift.GiftId)
                            .Select(d => d.Donors.DonorFullName)
                            .ToList();

                        gift.DonorToGift = donors;

                        giftsWithDonors.Add(gift);
                    }
                    foreach (var gift in giftsWithDonors)
                    {
                        gift.Quantity = gifts.Count(g => g.GiftId == gift.GiftId);
                    }
                    var uniqueGifts = giftsWithDonors
                        .GroupBy(g => g.GiftId)
                        .Select(group => group.First())
                        .ToList();
                    return uniqueGifts;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }
            public async Task<List<Orders>> getById(int id)//צפיה ברכישת כרטיסים עבור כל מתנה
        {
            try
            {
                var ordersGift = await this.context.Orders
                               .Include(a => a.Gift)
                               .Include(a => a.User)
                               .Where(o => o.Gift.GiftId == id)
                               .ToListAsync();

                foreach (var o in ordersGift)
                {
                    var user = await this.context.User.Where(a => a.UserId == o.UsersId).FirstOrDefaultAsync();
                    o.User = user;
                }


                return ordersGift;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }
        public async Task<List<Gift>> add(Gift gift1, User middlewareUser)//הוספת הזמנה לסל
        {
            try
            {
                var quantity = gift1.Quantity;

                for (var item = 0; item < quantity; item++)
                {
                    Orders Order1 = new Orders();
                    Order1.GiftId = gift1.GiftId;
                    Order1.Status = "chart";
                    Order1.UsersId = middlewareUser.UserId;
                    await this.context.Orders.AddAsync(Order1);
                    await this.context.SaveChangesAsync();

                }
                var z = await this.context.Orders
                  .Where(o => o.UsersId == middlewareUser.UserId && o.Status == "chart")
                  .Include(a => a.Gift)
                  .Select(o => o.Gift)
                  .ToListAsync();

                return z;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }
        public async Task<int> delete(int id, User middlewareUser)//מחיקת הזמנה מהסל
        {
            try
            {
                var order = await this.context.Orders
                               .FirstOrDefaultAsync(o => o.GiftId == id && o.UsersId == middlewareUser.UserId && o.Status == "chart");
                if (order == null) return 0;
                this.context.Orders.Remove(order);
                await this.context.SaveChangesAsync();

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }

        }
        public async Task<int> Put(Gift[] arr, User middlewareUser)
        {
            try
            {
                x = x + 7;
                if (arr.Length == 0) return 0;
                List<Orders> orderItems = new List<Orders>();//לקבל את הסל של המשתמש לפי התוקן
                OrderItems orderItems1 = new OrderItems();
                var orders = await this.context.Orders.ToListAsync();
                foreach (var order in orders)
                {
                    foreach (var gift in arr)
                    {
                        var quantity = gift.Quantity;
                        for (var item = 0; item < quantity; item++)
                        {

                            if (order.GiftId == gift.GiftId && order.Status != "payed" && order.UsersId == middlewareUser.UserId)//אולי לפי GiftId 
                            {
                                order.Status = "payed";
                                order.UsersId = middlewareUser.UserId;
                                await this.context.SaveChangesAsync();

                                orderItems.Add(order);
                                await this.context.SaveChangesAsync();

                            }
                        }
                    }
                }
                return 1;
                orderItems1.Date = DateTime.Now;
                orderItems1.Orders = orderItems;
                orderItems1.UsersId = middlewareUser.UserId;
                orderItems1.Id = x + 1;
                orderItems1.user = middlewareUser;

                await this.context.OrderItems.AddAsync(orderItems1);
                await this.context.SaveChangesAsync();
                return 2;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<List<OrderItems>> listItems()//פרטי רוכשים
        {

            return await this.context.OrderItems
                .Include(x => x.user)
                .Include(o => o.Orders)
                .ThenInclude(a => a.Gift)
                .ToListAsync();  
        }
        //מתרגלת למה לא עובד???///////////////////////////////////////////////////////////////////////////////
        public async Task<List<Gift>> orderByBest()
        {
            //var list =  await this.context.Gifts 
            //.OrderBy(g => this.context.Orders
            //.Include(a => a.Gift)
            //.Count(o => o.Gift.Status == "payed" && o.GiftId == g.GiftId))
            //.ToListAsync();

            var gifts = await context.Gifts.ToListAsync();

            var orderedGifts = gifts.OrderByDescending(g => context.Orders
            .Count(o => o.GiftId == g.GiftId  && o.Gift.Status=="payed")).ToList();
            return orderedGifts;
           
        }
    }
}
//return await _payingContext.Products
////            .OrderByDescending(product => _payingContext.OrderItem.Count(orderItem => orderItem.ProductId == product.ProductId))
////            .ToListAsync();
