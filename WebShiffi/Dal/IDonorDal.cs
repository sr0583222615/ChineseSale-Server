using webApi.models;
using WebShiffi.models;

namespace WebShiffi.Dal
{
    public interface IDonorDal
    {
        public  Task<List<Donors>> GetDonors();
        public Task<Donors> GetId(string id);
        public Task<int> addDonor(Donors g);
        public Task<Donors> updateadonor(string id, Donors d);
        public Task<int> delete(string id);//delete
        public Task<List<Donors>> getDonation(string id);


    }
}
