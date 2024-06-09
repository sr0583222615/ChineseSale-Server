using webApi.models;
using WebShiffi.Dal;
using WebShiffi.models;

namespace WebShiffi.Bal
{
    public class GiftService : IGiftService
    {
        private readonly IGiftDal igift;
        public GiftService(IGiftDal iGiftDal)
        {
            this.igift = iGiftDal ?? throw new ArgumentNullException(nameof(iGiftDal));
        }

        public Task<List<Gift>> GetGifts()
        {
            return this.igift.GetGift();
        }

        public Task<Gift> Getidbal(int id)
        {
            return this.igift.getID(id);
        }

        public Task<List<Gift>> addGift(Gift g)
        {

            return this.igift.addGift(g);
        }
        public Task<Donation> addDonation(Donation d)//add_donation
        {
            return this.igift.addDonation(d);

        }
        public int deleteGift(int id)
        {
            return this.igift.delete(id);

        }
        public Task<int> update(int id, Gift g)
        {
            return this.igift.update(id, g);
        }
        public Task<Gift> FilerName(string name)
        {
            return this.igift.filterByName(name);
            return null;
        }
        public Task<List<Gift>> FilerDonor(string name)
        {
            return this.igift.filterByDonor(name);
        }

        public Task<List<Gift>> FillterCategory(string category)
        {
            return this.igift.FillterCategory(category); }


        public Task<List<Gift>> FillterPrice(int price)
        {
            return this.igift.FillterPrice(price);  
        }
        public Task<List<Gift>> FillterByPriceHighe()
        {
            return this.igift.FillterByPriceHighe();
        }
        public Task<List<Gift>> FillterByPriceLow()
        {
          return this.igift.FillterByPriceLow();
        }

        public Task<List<Gift>> FillterByOrders(int n)//filter by orders
        {
            return this.igift.FillterByOrders(n);
        }
    }

}
