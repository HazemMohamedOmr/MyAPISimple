using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPISimple.Infrastructure.Data.Seeds.Seeders
{
    public class AddCoachRoleSeeder : ISeeder
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Coach",
                        NormalizedName = "Coach".ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    }
                );
        }
    }
}