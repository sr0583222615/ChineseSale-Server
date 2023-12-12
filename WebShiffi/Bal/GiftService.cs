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

        public Task<List<object>> GetGifts()
        {
            return this.igift.GetGift();
        }

        public Task<object> Getidbal(int id)
        {
            return this.igift.getID(id);
        }
     
        public Task<Gift> addGift(Gift g)
        {
         
            return this.igift.addGift(g);
        }
        public Task<Donation> addDonation(Donation d)
        {
           return this.igift.addDonation(d);

        }
        public int deleteGift(int id)
        {
           return this.igift.delete(id);
           
        }
        public Task<Gift> update(int id, Gift g)
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
    }


}
