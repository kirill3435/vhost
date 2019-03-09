using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AVideoHost.Models;

namespace AVideoHost.Data.Mappings
{
    public class TitleItemMap : IEntityTypeConfiguration<TitleItem>
    {
        public void Configure(EntityTypeBuilder<TitleItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Title).WithMany(x => x.Items).HasForeignKey(x => x.TitleId);
            builder.HasOne(x => x.Video).WithMany(x => x.TitleItems).HasForeignKey(x => x.VideoId);
        }
    }
}