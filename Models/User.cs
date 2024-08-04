using Microsoft.AspNetCore.Identity;

namespace Sales_Web.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }

}
