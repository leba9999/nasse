using ImageHandler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ImageHandler.Data
{
    public class ImageDbContext : DbContext
    {
        public ImageDbContext(DbContextOptions<ImageDbContext> options)
            : base(options)
        {
        }

        public ImageDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }

        public DbSet<MetaData> MetaData { get; set; }
        public DbSet<CameraData> CameraData { get; set; }
        public DbSet<Camera> Camera { get; set; }
        public DbSet<Extenssions> Extenssions { get; set; }
        public DbSet<Sizes> Sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Other configurations...

            // Configure the one-to-one relationship between Image and MetaData
            /*modelBuilder.Entity<Image>()
                .HasOne(image => image.Metadata)
                .WithOne(metadata => metadata.Image)
                .HasForeignKey<MetaData>(metadata => metadata.ImageId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed*/
            modelBuilder.Entity<Image>()
               .HasOne(image => image.Metadata)
               .WithOne(metadata => metadata.Image)
               .HasForeignKey<Image>(image => image.MetadataId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed
        }

    }
}
