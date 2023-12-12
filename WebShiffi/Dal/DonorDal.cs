using Microsoft.EntityFrameworkCore;
using webApi.Dal;
using webApi.models;

namespace WebShiffi.Dal
{
    public class DonorDal : IDonorDal
    {
        private readonly ChineseSaleContext ChineseSaleContext;
        public DonorDal(ChineseSaleContext ChineseSaleC)
        {
            this.ChineseSaleContext = ChineseSaleC ?? throw new ArgumentNullException(nameof(ChineseSaleC));
        }

        public async Task<List<Donors>> GetDonor()
        {
            return await this.ChineseSaleContext.Donors.ToListAsync();
        }

        public async Task<Donors> GetId(string id)
        {
            var p = await this.ChineseSaleContext.Donors

                .FirstOrDefaultAsync(p => p.DonorsId == id);


            return p;
        }
        public async Task<Donors> addDonor(Donors d)
        {
            await this.ChineseSaleContext.Donors.AddAsync(d);
            this.ChineseSaleContext.SaveChanges();
            return d;

        }
        public async Task<Donors> update(string id, Donors d)
        {
            var don = await this.ChineseSaleContext.Donors.FirstOrDefaultAsync(d => d.DonorsId == id);
            if (don == null)
                return null;
            else
            don.DonorFullName=d.DonorFullName;
            don.DonorPhone=d.DonorPhone;    
            don.DonorEmail=d.DonorEmail;    
            don.TypeOfGift=d.TypeOfGift;
            this.ChineseSaleContext.SaveChanges();
            return don;
        }
        public int delete(string id)
        {
            var dr = this.ChineseSaleContext.Donors
             .FirstOrDefault(d => d.DonorsId == id);
            if (dr != null)
            {
                ChineseSaleContext.Donors.Remove(dr);
                this.ChineseSaleContext.SaveChanges();
                return 1;
            }
            return 0;

        }
     
    }

}
