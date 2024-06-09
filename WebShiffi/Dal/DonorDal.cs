using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Xml.Linq;
using webApi.Dal;
using webApi.models;
using WebShiffi.models;

namespace WebShiffi.Dal
{
    public class DonorDal : IDonorDal
    {
        private readonly ChineseSaleContext ChineseSaleContext;
        public DonorDal(ChineseSaleContext ChineseSaleC)
        {
            this.ChineseSaleContext = ChineseSaleC ?? throw new ArgumentNullException(nameof(ChineseSaleC));
        }

        public async Task<List<Donors>> GetDonors()
        {
            try
            {
                var donors = await this.ChineseSaleContext.Donors.ToListAsync();

                foreach (var donor in donors)
                {
                    var don = await this.ChineseSaleContext.Donation
                        .Where(d => d.Donors.DonorsId == donor.DonorsId)
                        .Select(d => d.Gift.GiftName)
                        .ToListAsync();
                    donor.listDonation = don;
                }
                return donors;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
                 
        }
     
        public async Task<int> addDonor(Donors d)//add
        {
            try
            {
                await this.ChineseSaleContext.Donors.AddAsync(d);
                this.ChineseSaleContext.SaveChanges();
                if (d != null)
                    return 1;
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }


        }
        public async Task<Donors> updateadonor(string id, Donors d)//put
        {
            try
            {
                var don = await this.ChineseSaleContext.Donors.FirstOrDefaultAsync(d => d.DonorsId == id);
                if (don == null)
                    return null;
                else
                    don.DonorFullName = d.DonorFullName;
                don.DonorPhone = d.DonorPhone;
                don.DonorEmail = d.DonorEmail;
                don.TypeOfGift = d.TypeOfGift;
                don.listDonation = d.listDonation;

                this.ChineseSaleContext.SaveChanges();
                return don;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }
        public async Task<int> delete(string id)//delete
        {
            try
            {
                var dr = await this.ChineseSaleContext.Donors
                .FirstOrDefaultAsync(d => d.DonorsId == id);
                    ChineseSaleContext.Donors.Remove(dr);
                    this.ChineseSaleContext.SaveChanges();
                    return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }
        }
    public async Task<Donors> GetId(string name)//by donorName/email
        {
            try {
                var donor = await this.ChineseSaleContext.Donors
                .FirstOrDefaultAsync(p => p.DonorFullName == name || p.DonorEmail == name);
                var don = await this.ChineseSaleContext.Donation
                    .Where(d => d.Donors.DonorsId == donor.DonorsId)
                    .Select(d => d.Gift.GiftName)
                    .ToListAsync();
                donor.listDonation = don;

                return donor;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }

    

        public async Task<List<Donors>> getDonation(string name)// donation by //
        {
            try
            {
                var donors = await this.ChineseSaleContext.Donation
                               .Where(d => d.Gift.GiftName == name).Select(d => d.Donors).ToListAsync();
                foreach (var donor in donors)
                {
                    var don = await this.ChineseSaleContext.Donation
                        .Where(d => d.Donors.DonorsId == donor.DonorsId)
                        .Select(d => d.Gift.GiftName)
                        .ToListAsync();
                    donor.listDonation = don;
                }
                if (donors != null)
                    return donors;
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }



    }

}
