using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class Prn212Context : DbContext
{
    public Prn212Context()
    {
    }

    public Prn212Context(DbContextOptions<Prn212Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<CourtCondition> CourtConditions { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TimeSlot> TimeSlots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PRN212;User ID=sa;Password=12345;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BId).HasName("PK__Booking__4B26EFE63F35397E");

            entity.ToTable("Booking");

            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.BBookingType)
                .HasMaxLength(100)
                .HasColumnName("B_Booking_Type");
            entity.Property(e => e.BGuestName)
                .HasMaxLength(100)
                .HasColumnName("B_Guest_Name");
            entity.Property(e => e.BTotalHours).HasColumnName("B_Total_Hours");
            entity.Property(e => e.CoId).HasColumnName("CO_ID");

            entity.HasOne(d => d.Co).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking.CO_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_User");
        });

        modelBuilder.Entity<Court>(entity =>
        {
            entity.HasKey(e => e.CoId).HasName("PK__Court__F38FB8F5BF7B6E96");

            entity.ToTable("Court");

            entity.Property(e => e.CoId).HasColumnName("CO_ID");
            entity.Property(e => e.CoAddress)
                .HasMaxLength(255)
                .HasColumnName("CO_Address");
            entity.Property(e => e.CoBeneficiaryAccountName)
                .HasMaxLength(50)
                .HasColumnName("CO_BeneficiaryAccountName");
            entity.Property(e => e.CoBeneficiaryPayPalEmail)
                .HasMaxLength(255)
                .HasColumnName("CO_BeneficiaryPayPalEmail");
            entity.Property(e => e.CoInfo)
                .HasMaxLength(1000)
                .HasColumnName("CO_Info");
            entity.Property(e => e.CoName)
                .HasMaxLength(255)
                .HasColumnName("CO_Name");
            entity.Property(e => e.CoPath)
                .HasMaxLength(255)
                .HasColumnName("CO_Path");
            entity.Property(e => e.CoPrice).HasColumnName("CO_Price");
            entity.Property(e => e.CoStatus).HasColumnName("CO_Status");

            entity.HasOne(d => d.User).WithMany(p => p.Courts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Court_User");
        });

        modelBuilder.Entity<CourtCondition>(entity =>
        {
            entity.HasKey(e => e.CdId);

            entity.ToTable("CourtCondition");

            entity.Property(e => e.CdId).HasColumnName("CD_ID");
            entity.Property(e => e.CdCleanlinessCondition).HasColumnName("CD_CleanlinessCondition");
            entity.Property(e => e.CdCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CD_CreatedAt");
            entity.Property(e => e.CdLightningCondition).HasColumnName("CD_LightningCondition");
            entity.Property(e => e.CdNetCondition).HasColumnName("CD_NetCondition");
            entity.Property(e => e.CdNotes).HasColumnName("CD_Notes");
            entity.Property(e => e.CdOverallCondition).HasColumnName("CD_OverallCondition");
            entity.Property(e => e.CdSurfaceCondition).HasColumnName("CD_SurfaceCondition");
            entity.Property(e => e.CoId).HasColumnName("CO_ID");

            entity.HasOne(d => d.Co).WithMany(p => p.CourtConditions)
                .HasForeignKey(d => d.CoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourtCondition_Court");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Payment__A3420A77203B0044");

            entity.ToTable("Payment");

            entity.Property(e => e.PId).HasColumnName("P_ID");
            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.PAmount)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("P_Amount");
            entity.Property(e => e.PDateTime)
                .HasColumnType("datetime")
                .HasColumnName("P_Date_Time");

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment.B_ID");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__Rating__FCCDF87C42977EFF");

            entity.ToTable("Rating");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Rating1).HasColumnName("Rating");

            entity.HasOne(d => d.Court).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Court_Rating");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(56);

            entity.HasMany(d => d.Users).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_User_Role_User"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_User_Role_Role"),
                    j =>
                    {
                        j.HasKey("RoleId", "UserId");
                        j.ToTable("User_Role");
                        j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                    });
        });

        modelBuilder.Entity<TimeSlot>(entity =>
        {
            entity.HasKey(e => e.TsId).HasName("PK__TimeSlot__D128865AD75A2392");

            entity.ToTable("TimeSlot");

            entity.Property(e => e.TsId).HasColumnName("TS_ID");
            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.CoId).HasColumnName("CO_ID");
            entity.Property(e => e.TsCheckedIn).HasColumnName("TS_Checked_in");
            entity.Property(e => e.TsDate).HasColumnName("TS_Date");
            entity.Property(e => e.TsTime)
                .HasMaxLength(100)
                .HasColumnName("TS_Time");

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.TimeSlots)
                .HasForeignKey(d => d.BId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Time Slot.B_ID");

            entity.HasOne(d => d.Co).WithMany(p => p.TimeSlots)
                .HasForeignKey(d => d.CoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Time Slot.CO_ID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
