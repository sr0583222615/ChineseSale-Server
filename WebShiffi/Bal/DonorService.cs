using webApi.models;
using WebShiffi.Dal;

namespace WebShiffi.Bal
{
    public class DonorService :IDonorService
    {
      private  readonly IDonorDal donorD;
        public DonorService(IDonorDal donorDal)
        {
            this.donorD = donorDal ?? throw new ArgumentNullException(nameof(donorDal));
        }

        public Task<List<Donors>> GetDonors()///get
        {
            return this.donorD.GetDonor();
        }

        public Task<Donors> GetId(string id)//getId
        {
            return this.donorD.GetId(id);
        }

     

        public Task<Donors> addDonor(Donors d)//add
        {
            return this.donorD.addDonor(d);
        }

        public Task<Donors> update(string id, Donors g)//update
        {
            return this.update(id, g);
        }

        public int delete(string id)//delete
        {
           return this.donorD.delete(id); 
        }

    }
}


