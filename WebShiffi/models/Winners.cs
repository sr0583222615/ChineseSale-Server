namespace webApi.models
{
    public class Winners
    {
        public int WinnersId { get; set; }


        public int GiftId { get; set; }

        public Gift Gift { get; set; }


        public string UsersId { get; set; }

        public Users Users { get; set; }


        public int RafflesId { get; set; }
        public Raffles Raffles { get; set; }






    }
}
