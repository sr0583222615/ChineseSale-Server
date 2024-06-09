using ActiveUp.Net.Security.OpenPGP.Packets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webApi.models;
using WebShiffi.Bal;
using WebShiffi.DAL;
using WebShiffi.models;

namespace WebShiffi.BL
{
    public class UserService:IUserService
        
    {
        private readonly IUserDal userDal;
        private readonly IConfiguration _configuration;

        public UserService(IUserDal UserDal, IConfiguration _configuration)
        {
            this.userDal = UserDal ?? throw new ArgumentNullException(nameof(userDal));
            this._configuration=  _configuration ?? throw new ArgumentNullException(nameof(_configuration));

        }

        public Task<User> Authenticate(UserLogin user) 
        {
            return this.userDal.Authenticate(user);

        }
        //public string Generate(User user,HttpContext httpContext)
        //{           
        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //        var claims = new[]
        //        {
        //        new Claim(ClaimTypes.NameIdentifier,user.UserName),
        //        new Claim(ClaimTypes.Email,user.UserEmail),
        //        new Claim(ClaimTypes.Role,user.Role),
        //        new Claim(ClaimTypes.NameIdentifier,user.FirstName),
        //        new Claim(ClaimTypes.NameIdentifier,user.LastName),
        //        new Claim(ClaimTypes.HomePhone,user.UserPhone),
        //        //  UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
        //        //LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
        //        //UserPhone = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.HomePhone)?.Value,
        //        //UserEmail = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
        //        //FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
        //        //Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,

        //    };
        //        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
        //            _configuration["Jwt:Audience"],
        //            claims,
        //            expires: DateTime.UtcNow.AddMinutes(15),
        //            signingCredentials: credentials);


        //    var middlewareUser = httpContext.Items["User"] as User;

        //    return new JwtSecurityTokenHandler().WriteToken(token);


        //}

        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                 new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.UserEmail),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.NameIdentifier,user.FirstName),
                new Claim(ClaimTypes.NameIdentifier,user.LastName),
                new Claim(ClaimTypes.HomePhone,user.UserPhone),
                new Claim(ClaimTypes.UserData,user.UserId),

            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }



        public  Task<int> add(User user)
        {
            return this.userDal.add(user);
        }

    }
}
