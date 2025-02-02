using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPISimple.Infrastructure.Data.Seeds.Seeders
{
    public class AddMoreRolesSeeder : ISeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = "5f6609b0-b5cb-4756-ae2e-e18042cce2e48",
                        Name = "Hazem",
                        NormalizedName = "Hazem".ToUpper(),
                        ConcurrencyStamp = "a2c72caa-55e5-43bc-9719-c7da3c8eac62"
                    }
                );
        }
    }
}