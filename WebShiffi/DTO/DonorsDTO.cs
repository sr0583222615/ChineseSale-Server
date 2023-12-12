using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using WebShiffi.models;

namespace webApi.models
{
    public class DonorsDTO
    {
        //public int Id { get; set; }
        public string DonorsId { get; set; }
        public string DonorFullName { get; set; }
        public string DonorPhone { get; set; }
        public string DonorEmail { get; set; }
        public string TypeOfGift { get; set; }

      //  [NotMapped]
      //public virtual List<Donation> donations { get; set; }
    }
}
