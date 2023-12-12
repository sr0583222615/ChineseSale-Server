using webApi.models;

namespace WebShiffi.models
{
    public class DonationDTO
    {

        public int DonationId { get; set; }
        public DonorsDTO Donors { get; set; }
        public GiftDTO Gift   { get; set; }
         

    }
}
 