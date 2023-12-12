using webApi.models;

namespace WebShiffi.Bal
{
    public interface IDonorService
    {
        public Task<List<Donors>> GetDonors();
        public Task<Donors> GetId(string id);
        public Task<Donors> addDonor(Donors d);

        public Task<Donors> update(string id, Donors g);

        public int delete(string id);



    }
}
