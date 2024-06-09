using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using webApi.models;
using WebShiffi.DAL;

namespace WebShiffi.BL
{
    public class WinnerService:IWinnerService
    {
        private readonly IWinnerDal winnerDal;
        public WinnerService(IWinnerDal winnerDal) 
        {
            this.winnerDal = winnerDal ?? throw new ArgumentNullException(nameof(winnerDal));
        }
        public Task<string> raffle(int giftId)
        {
            return this.winnerDal.raffle(giftId);

        }
        public async Task<List<Winners>> listOfWinners()
        {
           return await this.winnerDal.listOfWinners();
        }

        public  Task<int> allMony()
        {
            return this.winnerDal.allMony();
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("DESKTOP-E0FAPSB") // הגדר את שם השרת SMTP שלך
            {
                Port = 7219, // פורט לשרת SMTP (ניתן לשנות לפורט המתאים של השרת שלך)
                Credentials = new NetworkCredential("ros5879320@gmail.com", "214388480"), // פרטי הכניסה לחשבון הדוא"ל שלך
                EnableSsl = true // אפשר SSL אם השרת מצריך
            };

            var message = new MailMessage
            {
                From = new MailAddress("ros5879320@gmail.com"), // כתובת הדוא"ל שבה תישלח ההודעה
                Subject = subject,
                Body = body
            };
            message.To.Add(recipientEmail); // כתובת הדוא"ל שאליה תישלח ההודעה

            await smtpClient.SendMailAsync(message); // שליחת הדוא"ל אסינכרונית
        }
    }
}
