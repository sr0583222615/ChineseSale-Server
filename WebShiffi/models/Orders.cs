using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.models
{
 public class Orders
    {
        
        public int OrdersId { get; set; }

        public int GiftId { get; set; }

        public Gift Gift { get; set; }


        public string UsersId { get; set; }

        public User User { get; set; }

        public string Status { get; set; }
        //[NotMapped]
        //public int Quantity { get; set; }

    }
}
        