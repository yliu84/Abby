using Microsoft.AspNetCore.Identity;

namespace AbbyRestaurant.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
