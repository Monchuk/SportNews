using Microsoft.AspNetCore.Identity;
using SportNewsBackend.Sport.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Sport.DataAccess.Models;

namespace Sport.API.Extentions
{
    public static class IdentityManager
    {
        public static void ConfigureIdentity(this IServiceCollection services) 
        {
            var builder = services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
