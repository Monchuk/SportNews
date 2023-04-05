using Microsoft.AspNetCore.Identity;
using SportNewsBackend.Sport.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Sport.DataAccess.Models;

namespace Sport.API.Extentions
{
    public static class IdentityConfiguration
    {
        public static void ConfigureIdentity(this IServiceCollection services) 
        {
            var builder = services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = true;
                o.Password.RequireNonAlphanumeric = false;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
