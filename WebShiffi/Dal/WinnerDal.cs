using Microsoft.EntityFrameworkCore;
using webApi.Dal;
using webApi.models;
using WebShiffi.models;

namespace WebShiffi.DAL
{
    public class WinnerDal : IWinnerDal
    {
        private readonly ChineseSaleContext ChineseSaleContext;
        public WinnerDal(ChineseSaleContext _context)
        {
            this.ChineseSaleContext = _context ?? throw new ArgumentNullException(nameof(ChineseSaleContext));
        }

        public async Task<List<Winners>> listOfWinners()
        {
            try
            {
                return await this.ChineseSaleContext.Winners
                               .Include(a => a.Gift)
                               .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }
        public async Task<int> allMony()
        {
            try
            {
                var mony = await this.ChineseSaleContext.Orders
                               .SumAsync(o => o.Gift.GiftTicketCost);
                return mony;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }

        }

        public async Task<string> raffle(int giftId)
        {
            try
            {
                var gift = await this.ChineseSaleContext.Gifts
                   .FirstOrDefaultAsync(g => g.GiftId == giftId);
                if (gift == null)
                    return "not exist";
                if (gift.Status != "after")
                {
                    Random random = new Random();
                    var orders = await this.ChineseSaleContext.Orders
                        .Where(o => o.GiftId == giftId)
                        .Select(o => o.UsersId)
                        .ToListAsync();
                    if (orders.Count == 0)
                        return "not  in the orders";
                    int randomIndex = random.Next(0, orders.Count);
                    string winner = orders[randomIndex];
                    var user = await this.ChineseSaleContext.User
                        .FirstOrDefaultAsync(u => u.UserId == winner);

                    Winners w = new Winners();
                    w.WinnerName = user.FirstName + " " + user.FirstName;
                    w.Gift = gift;
                    gift.Status = "after";
                    await this.ChineseSaleContext.Winners.AddAsync(w);
                    await this.ChineseSaleContext.SaveChangesAsync();
                    return user.FirstName + " " + user.LastName;
                }
                return "raffled";
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }


        }

 



    }
}
