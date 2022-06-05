using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IlisuHiltopHeaven.Data.Concrete.EntityFramework.Context;
using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using IlisuHiltopHeaven.Data.Concrete.EntityFramework;

namespace IlisuHiltopHeaven.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<IlisuHiltopHeavenContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddIdentity<User, Role>(options => {
                // User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                // User Username and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<IlisuHiltopHeavenContext>();
            serviceCollection.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(15); // after assigning new changes (ex: roles), the user is logged out after 15 minutes
            });

            return serviceCollection;
        }
    }
}
