using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MyAPISimple.Infrastructure.Data.Seeds
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            AddRolesSeeder(modelBuilder);
            AddRolessSeeder(modelBuilder);
        }
        private static void AddRolesSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = "9c639f86-250b-469e-b7b9-c8d7eb5fd648",
                        Name = "User",
                        NormalizedName = "User".ToUpper(),
                        ConcurrencyStamp = "f95c6b23-a00e-43df-a1d0-acecae2ff2d0"
                    },
                    new IdentityRole
                    {
                        Id = "89a5e7a5-a7cb-4b71-8c7d-50bd9c3ce319",
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper(),
                        ConcurrencyStamp = "3f8e49c7-aca0-4fc2-82f6-b3a17b2c575d"
                    }
                );
        }
        private static void AddRolessSeeder(ModelBuilder modelBuilder)
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