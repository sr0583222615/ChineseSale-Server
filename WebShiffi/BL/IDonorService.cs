using webApi.models;
using WebShiffi.models;

namespace WebShiffi.Bal
{
    public interface IDonorService
    {
        public Task<List<Donors>> GetDonors();
        public Task<Donors> GetId(string id);
        public Task<int> addDonor(Donors d);

        public Task<Donors> update(string id, Donors g);

        public Task<int> delete(string id);//delete

        public Task<List<Donors>> GetDonation(string id);///getDonation

      


    }
}
