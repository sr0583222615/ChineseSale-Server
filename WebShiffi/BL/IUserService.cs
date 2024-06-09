using Microsoft.AspNetCore.Mvc;
using webApi.models;
using WebShiffi.models;

namespace WebShiffi.BL
{
    public interface IUserService
    {


        public Task<User> Authenticate(UserLogin user);
        public string Generate(User user);
        public Task<int> add(User user);

    }
}
