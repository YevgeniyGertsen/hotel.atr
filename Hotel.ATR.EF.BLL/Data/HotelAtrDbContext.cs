using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Hotel.ATR.EF.BLL.Model;

namespace Hotel.ATR.EF.BLL.Data
{
    public partial class HotelAtrDbContext : DbContext
    {
        public HotelAtrDbContext()
        {
        }

        public HotelAtrDbContext(DbContextOptions<HotelAtrDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Availabilty> Availabilties { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventCategory> EventCategories { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Picture> Pictures { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomProperty> RoomProperties { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Availabilty>(entity =>
            {
                entity.HasKey(e => e.AvailabilityId);

                entity.ToTable("Availabilty");

                entity.Property(e => e.ReservationEnd).HasColumnType("datetime");

                entity.Property(e => e.ReservationStart).HasColumnType("datetime");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.ContentEvent).HasMaxLength(255);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ExparyDate).HasColumnType("datetime");

                entity.Property(e => e.ImagePath).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.EventCategory)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventCategoryId)
                    .HasConstraintName("FK_Event_EventCategory");
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.ToTable("EventCategory");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Adres).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ExparyDate).HasColumnType("datetime");

                entity.Property(e => e.ImagePath).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("Picture");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.UrlPicture).HasMaxLength(500);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Picture_Room");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<RoomProperty>(entity =>
            {
                entity.HasKey(e => e.RoomPropertiesId);

                entity.Property(e => e.RoomPropertiesId).ValueGeneratedNever();

                entity.Property(e => e.NamePropery)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValuePropery)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
