using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices;
using webApi.Dal;
using webApi.models;
using WebShiffi.Migrations;
using WebShiffi.models;
namespace WebShiffi.Dal
{
    public class GiftDal : IGiftDal
    {
        private readonly ChineseSaleContext _ChineseSaleContext;
        public GiftDal(ChineseSaleContext ChineseSaleC)
        {
            this._ChineseSaleContext = ChineseSaleC ?? throw new ArgumentNullException(nameof(ChineseSaleC));
        }
        public async Task<List<object>> GetGift()//get
        {
            var gifts = await this._ChineseSaleContext.Gifts.ToListAsync();
            var giftsWithDonors = new List<object>();

            foreach (var gift in gifts)
            {
                var donors = this._ChineseSaleContext.Donation
                    .Where(d => d.Gift.GiftId == gift.GiftId)
                    .Select(d => d.Donors.DonorFullName)
                    .ToList();

                gift.DonorToGift = donors;

                giftsWithDonors.Add(gift);
            }
            return giftsWithDonors;
        }

        //return await _ordersContext.Customer
        //       .Include(c => c.Orders)
        //       .ThenInclude(o => o.OrderDetails)
        //       .ThenInclude(od => od.Product)
        //       .Where(c => c.Id == customerId)
        //       .SelectMany(c => c.Orders)
        //       .SelectMany(o => o.OrderDetails)
        //       .Select(od => od.Product)
        //       .ToListAsync();



        public async Task<object> getID(int id)//get_id
        {
            var p = await this._ChineseSaleContext.Donation
                .Select(d => new
                {
                    donor = d.Donors.DonorFullName,
                    gift = d.Gift
                })
                .Where(p => p.gift.GiftId == id).ToListAsync();
            return p;
        }
        public async Task<Gift> addGift(Gift g)//add_gift
        {
            await this._ChineseSaleContext.Gifts.AddAsync(g);
            this._ChineseSaleContext.SaveChanges();
            return g;
        }
        public async Task<Donation> addDonation(Donation d)//add_donation
        {
            await this._ChineseSaleContext.Donation.AddAsync(d);
            //await this._ChineseSaleContext.Donation.Donors.DonorToGift.AddAsync(d); 
            this._ChineseSaleContext.SaveChanges();
            return d;
        }
        public int delete(int id)//delete
        {
            var gf = this._ChineseSaleContext.Gifts
             .FirstOrDefault(d => d.GiftId == id);
            if (gf != null)
            {
                _ChineseSaleContext.Gifts.Remove(gf);
                this._ChineseSaleContext.SaveChanges();
                return 1;
            }
            return 0;

        }
        public async Task<Gift> update(int id, Gift g)//update
        {
            var gif = await this._ChineseSaleContext.Gifts.FirstOrDefaultAsync(d => d.GiftId == id);
            if (gif == null)
                return null;
            else
                gif.GiftName = g.GiftName;
            gif.GiftTicketCost = g.GiftTicketCost;
            gif.GiftDiscription = g.GiftDiscription;
            gif.GiftCatagory = g.GiftCatagory;
            gif.GiftUrlImage = g.GiftUrlImage;
            this._ChineseSaleContext.SaveChanges();
            return gif;
        }

        public async Task<Gift> filterByName(string name)//filterByName
        {
            var giftName = await this._ChineseSaleContext.Gifts.FirstOrDefaultAsync(g => g.GiftName == name);
            if (giftName != null)
            {
                return giftName;
            }
            return null;
        }

        public async Task<List<Gift>> filterByDonor(string name)//filterByDonor
        {
            var giftDonor = await this._ChineseSaleContext.Donation.Where(g => g.Donors.DonorFullName == name).Select(a=>a.Gift).ToListAsync();
            if (giftDonor != null)
            {
                return giftDonor;
            }
            return null;
        }
        //public async Task<List<object>> filterByDonor(string name)
        //{
        //    {
        //        var giftWithDonor = await this._ChineseSaleContext.Donation
        //            .Select(d => new
        //            {
        //                donorName = d.Donors.DonorFullName,
        //                gift = d.Gift
        //            })
        //            .Where(g => g.donorName == name).ToListAsync();

        //        if (giftWithDonor != null)

        //        {
        //            return giftWithDonor.Cast<object>().ToList();
        //        }
        //        return null;
        //    }


        //}
    }
}
