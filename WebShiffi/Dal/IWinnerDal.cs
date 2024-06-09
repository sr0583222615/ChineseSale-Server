using webApi.models;

namespace WebShiffi.DAL
{
    public interface IWinnerDal
    {
        public Task<string> raffle(int giftId);
        public  Task<List<Winners>> listOfWinners();

        public  Task<int> allMony();

    }
}
