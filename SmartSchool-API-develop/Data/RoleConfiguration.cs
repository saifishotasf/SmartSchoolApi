using EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                    new Role { Id = 1, Name = "Admin"},
                    new Role { Id = 2, Name = "Teacher" },
                    new Role { Id = 3, Name = "Clark" },
                    new Role { Id = 4, Name = "Student" }
                );

        }
    }
}
