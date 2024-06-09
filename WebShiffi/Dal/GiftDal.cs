using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices;
using webApi.Dal;
using webApi.models;
using WebShiffi.DAL;
using WebShiffi.models;
namespace WebShiffi.Dal
{
    public class GiftDal : IGiftDal
    {
        private readonly ChineseSaleContext _ChineseSaleContext;
        private readonly IMapper mapper;

        public GiftDal(ChineseSaleContext ChineseSaleC, IMapper mapper)
        {
            this._ChineseSaleContext = ChineseSaleC ?? throw new ArgumentNullException(nameof(ChineseSaleC));
            this.mapper = mapper;
        }
        public async Task<List<Gift>> GetGift()//get
        {
            try
            {
                var gifts = await this._ChineseSaleContext.Gifts.ToListAsync();
                var giftsWithDonors = new List<Gift>();

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
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }
        public async Task<Gift> getID(int id)//get_id
        {
            try
            {
                var p = await this._ChineseSaleContext.Gifts
                               .FirstOrDefaultAsync(g => g.GiftId == id);

                return p;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }
        public async Task<List<Gift>> addGift(Gift g)//add_gift
        {
            try
            {
                await this._ChineseSaleContext.Gifts.AddAsync(g);
                this._ChineseSaleContext.SaveChanges();

                var list = g.DonorToGift.ToList();
                for (var i = 0; i < list.Count; i++)
                {
                    var d = list[i];
                    var donor = await this._ChineseSaleContext.Donors
                        .FirstOrDefaultAsync(a => a.DonorsId == d);
                    if (donor != null)
                    {
                        Donation donation = new Donation();
                        donation.Donors = donor;
                        donation.Gift = g;
                        await this._ChineseSaleContext.Donation.AddAsync(donation);
                    }
                }
                this._ChineseSaleContext.SaveChanges();
                if (g != null)
                    return this._ChineseSaleContext.Gifts.ToList();
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }
        public async Task<Donation> addDonation(Donation d)//add_donation
        {
            try
            {
                var gift = d.Gift;
                var donor = d.Donors;
                if (gift != null)
                {
                    await this._ChineseSaleContext.Gifts.AddAsync(gift);
                    await this._ChineseSaleContext.Donation.AddAsync(d);
                    await this._ChineseSaleContext.Donors.AddAsync(donor);
                    this._ChineseSaleContext.SaveChanges();

                }
                return d;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }
        public int delete(int id)//delete
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }

        }
        public async Task<int> update(int id, Gift g)//update gift
        {
            try
            {
                var gif = await this._ChineseSaleContext.Gifts.FirstOrDefaultAsync(d => d.GiftId == id);
                if (gif == null)
                    return 0;
                else
                    gif.GiftName = g.GiftName;
                gif.GiftTicketCost = g.GiftTicketCost;
                gif.GiftDiscription = g.GiftDiscription;
                gif.GiftCatagory = g.GiftCatagory;
                gif.GiftUrlImage = g.GiftUrlImage;
                //gif.Quantity = g.Quantity;
                this._ChineseSaleContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }

        }

        public async Task<Gift> filterByName(string name)//filterByName 1
        {
            try
            {
                var giftName = await this._ChineseSaleContext.Gifts
             .FirstOrDefaultAsync(g => g.GiftName == name);
                if (giftName != null)
                {
                    return giftName;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }

        public async Task<List<Gift>> filterByDonor(string name)//filterByDonor list
        {
            try
            {
                var giftDonor = await this._ChineseSaleContext.Donation.Where(g => g.Donors.DonorFullName == name).Select(a => a.Gift).ToListAsync();
                if (giftDonor != null)
                {
                    return giftDonor;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }
        public async Task<List<Gift>> FillterCategory(string category)//filter by category list
        {
            try
            {
                var giftCategory = await this._ChineseSaleContext.Gifts
                            .Where(g => g.GiftCatagory == category).ToListAsync();
                if (giftCategory == null)
                    return null;
                return giftCategory;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }

        public async Task<List<Gift>> FillterPrice(int price)//filletr by price
        {
            try
            {
                var gift = await this._ChineseSaleContext.Gifts
                               .Where(g => g.GiftTicketCost == price).ToListAsync();
                if (gift == null)
                    return null;
                return gift;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }
        public async Task<List<Gift>> FillterByPriceLow()//fiter by order
        {
            try
            {
                var gift = await this._ChineseSaleContext.Gifts
                                .OrderBy(g => g.GiftTicketCost)
                               .ToListAsync();
                if (gift == null)
                    return null;
                return gift;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }
        public async Task<List<Gift>> FillterByPriceHighe()//filter by desting
        {
            try
            {
                var gift = await this._ChineseSaleContext.Gifts
                                .OrderByDescending(g => g.GiftTicketCost)
                               .ToListAsync();
                if (gift == null)
                    return null;
                return gift;
            }
            catch (Exception ex) {
                Console.WriteLine("error:" + ex.Message);
                return null;
            }
           
        }
        public async Task<List<Gift>> FillterByOrders(int n)//filter by des
        {
            try
            {
                List<Gift> gs = new List<Gift>();
                var gifts = await this._ChineseSaleContext.Gifts.ToListAsync();
                foreach (var g in gifts)
                {
                    var o = await this._ChineseSaleContext.Orders
                       .CountAsync(or => or.GiftId == g.GiftId);
                    if (o == n)
                    {
                        gs.Add(g);
                    }
                }
                return gs;
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }

    }
}
