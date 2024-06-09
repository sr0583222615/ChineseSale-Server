using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace webApi.models
{
    public class User
    {
        [DataType(DataType.Password)]
        [Key]
        [PasswordPropertyText]
        public string UserId { get; set; }
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "כתובת דואר אלקטרוני לא חוקית")]
        [Display(Name = "כתובת דואר אלקטרוני")]
        public string UserEmail { get; set; }

        [Phone]
        public string UserPhone { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Role { get; set; }




    }

}
