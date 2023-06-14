using Microsoft.AspNetCore.Identity;

namespace CoffeeShop.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}
