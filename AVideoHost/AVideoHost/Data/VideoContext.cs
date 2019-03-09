using Microsoft.EntityFrameworkCore;
using AVideoHost.Models;
using AVideoHost.Data.Mappings;

namespace AVideoHost.Data
{
    public class VideoContext : DbContext
    {
        public VideoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Video> Video { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TitleMap());
            modelBuilder.ApplyConfiguration(new VideoMap());
        }
    }
}
