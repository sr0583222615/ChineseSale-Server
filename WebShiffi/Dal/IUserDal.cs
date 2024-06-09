using Microsoft.AspNetCore.Mvc;
using webApi.models;
using WebShiffi.models;

namespace WebShiffi.DAL
{
    public interface IUserDal
    {
        public Task<User> Authenticate(UserLogin user);
        public  Task<int> add(User user);


    }
}
