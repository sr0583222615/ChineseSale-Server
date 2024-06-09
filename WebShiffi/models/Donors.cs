using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShiffi.models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webApi.models
{
    public class Donors
    {
        //[PasswordPropertyText]
        public string DonorsId { get; set; }
        public string DonorFullName { get; set; }
        //[Phone]
        public string DonorPhone { get; set; }
        //[EmailAddress]
        public string DonorEmail { get; set; }
        public string TypeOfGift { get; set; }
        [NotMapped]
        public List<string> listDonation { get; set; }

        //[NotMapped]
        //public virtual List<string> listDonation { get; set; }
    }
}

