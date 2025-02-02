using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAPISimple.Infrastructure.Identity;

namespace MyAPISimple.Infrastructure.Data.Configurations
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            entity.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}