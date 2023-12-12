namespace webApi.models
{
 public class Orders
    {
        public int OrdersId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderSum { get; set;}
        public virtual ICollection<OrderItems> listOrderItems { get; set; }


    }
}
        