using webApi.models;

namespace WebShiffi.BL
{
    public interface IWinnerService
    {
        public Task<List<Winners>> listOfWinners();

        public Task<string> raffle(int giftId);
        public Task<int> allMony();
        public  Task SendEmailAsync(string recipientEmail, string subject, string body);


    }
}
