using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using webApi.models;

namespace WebShiffi.models
{
    public class OrderItems
    {


      

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public  virtual List<Orders> Orders { get; set; }

        public User user { get; set; }
        public string UsersId { get; set; }


        public int OrdersId { get; set; }

    }
}
