using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyAPISimple.Core.Interfaces;
using MyAPISimple.Infrastructure.Data;
using MyAPISimple.Infrastructure.Identity;
using MyAPISimple.Infrastructure.Repository;

namespace MyAPISimple.Services
{
    public static class ServiceExtensions
    {
        // Register UnitOfWork
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        // Register DbContext
        public static void ConfigureDataBaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });
        }
        // Register Identity
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}