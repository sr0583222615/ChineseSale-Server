using webApi.models;
using WebShiffi.models;

namespace WebShiffi.Dal
{
    public interface IGiftDal
    {

        public Task<List<Gift>> GetGift();
        public Task<Gift> getID(int id);
        public Task<List<Gift>> addGift(Gift g);
        public  Task<Donation> addDonation(Donation d);//add_donation
        public Task<int> update(int id ,Gift g);
        public int delete(int id);
        public Task<Gift> filterByName(string name);
        public Task<List<Gift>> filterByDonor(string name);//filterByDonor
        public Task<List<Gift>> FillterCategory(string category);//fillterBy Category

        public  Task<List<Gift>> FillterPrice(int price);

        public  Task<List<Gift>> FillterByPriceHighe();
        public  Task<List<Gift>> FillterByPriceLow();
        public Task<List<Gift>> FillterByOrders(int n);//filter by orders


    }
}