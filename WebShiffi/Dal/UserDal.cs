using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webApi.Dal;
using webApi.models;
using WebShiffi.models;

namespace WebShiffi.DAL
{
    public class UserDal:IUserDal
    { 

        private readonly ChineseSaleContext ChineseSaleContext;
        public UserDal(ChineseSaleContext _context)
        {
            this.ChineseSaleContext = _context ?? throw new ArgumentNullException(nameof(ChineseSaleContext));
        }

        public async Task<User> Authenticate(UserLogin user)
        {
            try
            {
                var currentUser = await ChineseSaleContext.User.FirstOrDefaultAsync(o => o.UserName.ToLower() == user.UserName.ToLower()
                           && o.UserId == user.Password);
                if (currentUser != null)
                {
                    return currentUser;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }

        }
        public async Task<int> add(User user)
        {
            try
            {
                if (user != null)
                {
                    await this.ChineseSaleContext.User.AddAsync(user);

                    await this.ChineseSaleContext.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }


        }
      



    }
}
