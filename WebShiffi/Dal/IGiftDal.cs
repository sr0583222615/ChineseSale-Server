using webApi.models;
using WebShiffi.Migrations;
using WebShiffi.models;

namespace WebShiffi.Dal
{
    public interface IGiftDal
    {

        public Task<List<object>> GetGift();

        public Task<object> getID(int id);
        public Task<Gift> addGift(Gift g);
        public Task<Donation> addDonation(Donation d);
        public Task<Gift> update(int id ,Gift g);

        public int delete(int id);
        public Task<Gift> filterByName(string name);


        public Task<List<Gift>> filterByDonor(string name);//filterByDonor


    }
}