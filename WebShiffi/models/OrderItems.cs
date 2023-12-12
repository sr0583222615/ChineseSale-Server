namespace webApi.models
{
    public class OrderItems
    {
        public int OrderItemsId { get; set; }

        
        public int OrdersId { get; set; }

        public Orders Orders { get; set; }

        public int GiftId { get; set; }

        public Gift Gift { get; set; }

        public string usersId { get; set; }

        public Users users { get; set; }

    }
}
