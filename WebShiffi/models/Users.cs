using Microsoft.AspNetCore.Identity;

namespace webApi.models
{
    public class Users
    {
       
        public string UsersId { get; set; } 
        public string UserName { get; set; }
        public string UserEmail { get; set;}

        public string UserPassword { get; set;}
        public string UserPhone { get; set;}

        public string firstName { get; set; }
        public string lastName { get; set;}
        public bool Role { get; set; }



    }
   
}
