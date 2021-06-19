using IdentityModel;
using mango.identity.server.Configurations;
using mango.identity.server.DbContext;
using mango.identity.server.Infrastructure.Database;
using mango.identity.server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace mango.product.api.Infrastructure.Database
{
    public class DbInitializerImpl : DbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public DbInitializerImpl(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }
        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
        public async Task SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                UserManager<ApplicationUser> userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                using (ApplicationDbContext applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    if (await roleManager.FindByNameAsync(Constants.Admin) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(Constants.Admin));
                        await roleManager.CreateAsync(new IdentityRole(Constants.Customer));
                    }
                    else
                    {
                        return;
                    }

                    var adminUser = new ApplicationUser()
                    {
                        UserName = "admin1@gmail.com",
                        Email = "admin1@gmail.com",
                        EmailConfirmed = true,
                        PhoneNumber = "1111111111",
                        FirstName = "Ben",
                        LastName = "Admin"
                    };
                    var claims = new List<Claim>()
                    {
                         new Claim(JwtClaimTypes.Name,$"{adminUser.FirstName} {adminUser.LastName}"),
                         new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                         new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                         new Claim(JwtClaimTypes.Role,Constants.Admin)
                     };
                    await userManager.CreateAsync(adminUser, "Admin123*");
                    await userManager.AddToRoleAsync(adminUser, Constants.Admin);
                    var result = await userManager.AddClaimsAsync(adminUser, claims);
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("Unable to add User");
                    }
                    var customerUser = new ApplicationUser()
                    {
                        UserName = "customer1@gmail.com",
                        Email = "customer1@gmail.com",
                        EmailConfirmed = true,
                        PhoneNumber = "1111111111",
                        FirstName = "Ben",
                        LastName = "customer"
                    };
                    var customerClaims = new List<Claim>()
                    {
                         new Claim(JwtClaimTypes.Name,$"{customerUser.FirstName} {customerUser.LastName}"),
                         new Claim(JwtClaimTypes.GivenName,customerUser.FirstName),
                         new Claim(JwtClaimTypes.FamilyName,customerUser.LastName),
                         new Claim(JwtClaimTypes.Role,Constants.Customer)
                     };
                    await userManager.CreateAsync(customerUser, "Customer123*");
                    await userManager.AddToRoleAsync(customerUser, Constants.Customer);
                    result = await userManager.AddClaimsAsync(customerUser, customerClaims);
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("Unable to add User");
                    }
                }
            }
        }
    }
}
