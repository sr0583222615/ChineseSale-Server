using webApi.models;

namespace WebShiffi.models
{
    public class Donation
    {

        public int DonationId { get; set; }
        public Donors Donors { get; set; }
        public Gift Gift   { get; set; }
         

    }
}
 