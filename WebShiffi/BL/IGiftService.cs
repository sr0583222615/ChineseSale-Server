using webApi.models;
using WebShiffi.models;

namespace WebShiffi.Bal
{
    public interface IGiftService
    {
         Task<List<Gift>> GetGifts();
        public Task<Gift> Getidbal(int id);

        public Task<List<Gift>> addGift(Gift g);
        public Task<Donation> addDonation(Donation d);//add_donation

        public Task<int> update(int id, Gift g);

        public int deleteGift(int num);
        public Task<Gift> FilerName(string name);

        public Task<List<Gift>> FilerDonor(string name);
        public Task<List<Gift>> FillterCategory(string category);
        public Task<List<Gift>> FillterPrice(int price);
        public Task<List<Gift>> FillterByPriceHighe();
        public Task<List<Gift>> FillterByPriceLow();
        public Task<List<Gift>> FillterByOrders(int n);//filter by orders


    }
}
