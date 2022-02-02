using AbbyRestaurant.DataAccess.Data;
using AbbyRestaurant.Models;
using AbbyRestaurant.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AbbyRestaurant.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {
            }

            if (!_roleManager.RoleExistsAsync(SD.KitchenRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.KitchenRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.ManagerRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.FrontDeskRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.CustomerRole)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "yangliu0127@gmail.com",
                    Email ="yangliu0127@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Yang",
                    LastName = "Liu"
                },"ly02195006").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.Email == "yangliu0127@gmail.com");

                _userManager.AddToRoleAsync(user, SD.ManagerRole).GetAwaiter().GetResult();
            }

            return;
        }
    }
}
