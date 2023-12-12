using webApi.models;
using WebShiffi.models;

namespace WebShiffi.Bal
{
    public interface IGiftService
    {
         Task<List<object>> GetGifts();
        public Task<object> Getidbal(int id);

        public  Task<Gift> addGift(Gift g);
        public Task<Donation> addDonation(Donation d);

        public Task<Gift> update(int id, Gift g);

        public int deleteGift(int num);
        public Task<Gift> FilerName(string name);

        public Task<List<Gift>> FilerDonor(string name);


    }
}
