using webApi.models;

namespace WebShiffi.Dal
{
    public interface IDonorDal
    {
        public Task<List<Donors>> GetDonor();
        public  Task<Donors> GetId(string id);

        public Task<Donors> addDonor(Donors g);
        public Task<Donors> update(string id, Donors d);

        public int delete(string id);

    }
}
