namespace webApi.models
{
 public class OrdersDTO
    {
        public int OrdersId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderSum { get; set;}
        public virtual ICollection<OrderItemsDTO> listOrderItems { get; set; }


    }
}
        