using webApi.models;
using WebShiffi.Dal;
using WebShiffi.models;

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
            return this.donorD.GetDonors();
        }

        public Task<Donors> GetId(string id)//getId
        {
            return this.donorD.GetId(id);
        }

        public Task<int> addDonor(Donors d)//add
        {
            return this.donorD.addDonor(d);
        }

        public Task<Donors> update(string id, Donors g)//update
        {
            return this.donorD.updateadonor(id, g); 
        }

        public Task<int> delete(string id)//delete
        {
           return this.donorD.delete(id); 
        }
        public Task<List<Donors>> GetDonation(string id)///getDonation
        {
            return this.donorD.getDonation(id);
        }
       
    }
}


