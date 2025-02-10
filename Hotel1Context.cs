using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelDomain.Model;

public partial class Hotel1Context : DbContext
{
    public Hotel1Context()
    {
    }

    public Hotel1Context(DbContextOptions<Hotel1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Hotelpl> Hotelpls { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Laura\\SQLEXPRESS; Database=hotel1; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACD20561B6A");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.GuestId).HasColumnName("GuestID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");

            entity.HasOne(d => d.Guest).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__GuestID__4316F928");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__RoomID__4222D4EF");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("PK__Guest__0C423C327D8EAB92");

            entity.ToTable("Guest");

            entity.HasIndex(e => e.PassportNumber, "UC_PassportNumber").IsUnique();

            entity.Property(e => e.GuestId).HasColumnName("GuestID");
            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PassportNumber).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber).HasMaxLength(25);
        });

        modelBuilder.Entity<Hotelpl>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotelpl__46023BBF7F999329");

            entity.ToTable("Hotelpl");

            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Address).HasMaxLength(800);
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A982479A4");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__328639198C5831A1");

            entity.ToTable("Room");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Room__HotelID__3C69FB99");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Room__RoomTypeID__3B75D760");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.RoomTypeId).HasName("PK__RoomType__BCC896116F077C21");

            entity.ToTable("RoomType");

            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 4)");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WorkerId).HasName("PK__Worker__077C8806718BB7FC");

            entity.ToTable("Worker");

            entity.Property(e => e.WorkerId).HasColumnName("WorkerID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Workers)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Worker__HotelID__47DBAE45");

            entity.HasOne(d => d.Role).WithMany(p => p.Workers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Worker__RoleID__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
