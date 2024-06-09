using System.ComponentModel.DataAnnotations.Schema;
using WebShiffi.models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webApi.models
{
    public class Gift
    {
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public string GiftCatagory { get; set; }
        public string GiftDiscription { get; set; }      
        public int GiftTicketCost { get; set; }
        public string GiftUrlImage { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public List<string> DonorToGift { get; set; }
        [NotMapped]
        public int Quantity { get; set; }

    }
}

