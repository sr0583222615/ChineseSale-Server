using System.ComponentModel.DataAnnotations.Schema;
using WebShiffi.models;

namespace webApi.models
{
    public class GiftDTO
    {
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public string GiftCatagory { get; set; }
        public string GiftDiscription { get; set; }
        public int GiftTicketCost { get; set; }
        public string GiftUrlImage { get; set; }
        [NotMapped]
        public virtual List<string> DonorToGift { get; set; }

    }
}
