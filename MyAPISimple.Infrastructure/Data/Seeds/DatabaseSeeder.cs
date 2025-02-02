using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyAPISimple.Infrastructure.Data.Seeds.Seeders;

namespace MyAPISimple.Infrastructure.Data.Seeds
{
    public static class DatabaseSeeder
    {
        private static readonly List<ISeeder> Seeders = new()
        {
            new AddRolesSeeder(),
            new AddMoreRolesSeeder(),
            new AddCoachRoleSeeder(),
        };

        public static void Seed(ModelBuilder modelBuilder)
        {
            foreach (var seeder in Seeders)
            {
                seeder.Seed(modelBuilder);
            }
        }
    }
}