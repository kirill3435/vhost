using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AVideoHost.Models;

namespace AVideoHost.Data.Mappings
{
    public class TitleMap : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Items);
        }
    }
}
