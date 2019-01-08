using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWFU.CMS.Core.Entities;

namespace SWFU.CMS.Insfrastructure.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Author).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Author).IsRequired().HasColumnType("nvarchar(max)");
            
        }
    }
}