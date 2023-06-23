using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessObjects
{
    public partial class VietnamgoContext : DbContext
    {
        public VietnamgoContext()
        {
        }

        public VietnamgoContext(DbContextOptions<VietnamgoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<LocationImage> LocationImages { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Tour> Tours { get; set; } = null!;
        public virtual DbSet<TourGuide> TourGuides { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=1234567890;Database=Vietnamgo;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("bookingDate");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("paymentDate");

                entity.Property(e => e.PaymentStatus).HasColumnName("paymentStatus");

                entity.Property(e => e.TourId).HasColumnName("tourId");

                entity.Property(e => e.TouristNum)
                    .HasColumnName("touristNum")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TripDate)
                    .HasColumnType("datetime")
                    .HasColumnName("tripDate");

                entity.Property(e => e.TripStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tripStatus")
                    .HasDefaultValueSql("('Pending')");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Booking__custome__1B9317B3");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TourId)
                    .HasConstraintName("FK__Booking__tourId__1C873BEC");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("lastName");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(30)
                    .HasColumnName("middleName");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Url)
                    .HasMaxLength(150)
                    .HasColumnName("url");

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("location_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .HasColumnName("address");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.Ranking)
                    .HasMaxLength(150)
                    .HasColumnName("ranking");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RawRanking)
                    .HasColumnName("raw_ranking")
                    .HasDefaultValueSql("((5))");
            });

            modelBuilder.Entity<LocationImage>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__Location__771831EA6CAEB09D");

                entity.Property(e => e.LocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("location_id");

                entity.Property(e => e.LargeId).HasColumnName("largeId");

                entity.Property(e => e.MediumId).HasColumnName("mediumId");

                entity.Property(e => e.OriginalId).HasColumnName("originalId");

                entity.Property(e => e.SmallId).HasColumnName("smallId");

                entity.Property(e => e.ThumbnailId).HasColumnName("thumbnailId");

                entity.HasOne(d => d.Large)
                    .WithMany(p => p.LocationImageLarges)
                    .HasForeignKey(d => d.LargeId)
                    .HasConstraintName("FK__LocationI__large__47A6A41B");

                entity.HasOne(d => d.Location)
                    .WithOne(p => p.LocationImage)
                    .HasForeignKey<LocationImage>(d => d.LocationId)
                    .HasConstraintName("FK__LocationI__locat__44CA3770");

                entity.HasOne(d => d.Medium)
                    .WithMany(p => p.LocationImageMedia)
                    .HasForeignKey(d => d.MediumId)
                    .HasConstraintName("FK__LocationI__mediu__46B27FE2");

                entity.HasOne(d => d.Original)
                    .WithMany(p => p.LocationImageOriginals)
                    .HasForeignKey(d => d.OriginalId)
                    .HasConstraintName("FK__LocationI__origi__489AC854");

                entity.HasOne(d => d.Small)
                    .WithMany(p => p.LocationImageSmalls)
                    .HasForeignKey(d => d.SmallId)
                    .HasConstraintName("FK__LocationI__small__45BE5BA9");

                entity.HasOne(d => d.Thumbnail)
                    .WithMany(p => p.LocationImageThumbnails)
                    .HasForeignKey(d => d.ThumbnailId)
                    .HasConstraintName("FK__LocationI__thumb__498EEC8D");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.Author)
                    .HasMaxLength(50)
                    .HasColumnName("author");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MachineTranslated)
                    .HasColumnName("machine_translated")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("published_date");

                entity.Property(e => e.PublishedPlatform)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("published_platform");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Summary)
                    .HasMaxLength(500)
                    .HasColumnName("summary");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Review__location__40058253");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.ToTable("Tour");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocationId).HasColumnName("locationId");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.TourDescription)
                    .HasMaxLength(500)
                    .HasColumnName("tourDescription");

                entity.Property(e => e.TourGuideId).HasColumnName("tourGuideId");

                entity.Property(e => e.TourName)
                    .HasMaxLength(50)
                    .HasColumnName("tourName");

                entity.Property(e => e.TourTime)
                    .HasMaxLength(20)
                    .HasColumnName("tourTime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tour__locationId__76619304");

                entity.HasOne(d => d.TourGuide)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.TourGuideId)
                    .HasConstraintName("FK__Tour__tourGuideI__756D6ECB");
            });

            modelBuilder.Entity<TourGuide>(entity =>
            {
                entity.ToTable("TourGuide");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("lastName");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(30)
                    .HasColumnName("middleName");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
