namespace webApi.models
{
    public class OrderItemsDTO
    {
        public int OrderItemsId { get; set; }

        
        public int OrdersId { get; set; }

        public OrdersDTO Orders { get; set; }

        public int GiftId { get; set; }

        public GiftDTO Gift { get; set; }

        public string usersId { get; set; }

        public UsersDTO users { get; set; }

    }
}
