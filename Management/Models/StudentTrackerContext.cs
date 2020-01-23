using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Management.Models
{
    public partial class StudentTrackerContext : DbContext
    {
        public virtual DbSet<AcadimacYears> AcadimacYears { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Grids> Grids { get; set; }
        public virtual DbSet<Presness> Presness { get; set; }
        public virtual DbSet<PresnessInfo> PresnessInfo { get; set; }
        public virtual DbSet<Schools> Schools { get; set; }
        public virtual DbSet<StudentEvents> StudentEvents { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Years> Years { get; set; }

        public StudentTrackerContext(DbContextOptions<StudentTrackerContext> options) : base(options) { }

        // Unable to generate entity type for table 'dbo.Packeges'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"server=LAPTOP-DVJT5BST;database=StudentTracker;uid=Ahmed;pwd=35087124567Ahmed;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcadimacYears>(entity =>
            {
                entity.HasKey(e => e.AcadimecYearId);

                entity.Property(e => e.CreatedBy).HasMaxLength(128);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.CreatedBy).HasMaxLength(128);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EventGroup).HasColumnType("nchar(10)");

                entity.HasOne(d => d.AcadimecYear)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.AcadimecYearId)
                    .HasConstraintName("FK_Events_AcadimacYears");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_Events_Years");
            });

            modelBuilder.Entity<Grids>(entity =>
            {
                entity.HasKey(e => e.Grid);

                entity.Property(e => e.CreatedBy).HasMaxLength(128);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.StudentEvent)
                    .WithMany(p => p.Grids)
                    .HasForeignKey(d => d.StudentEventId)
                    .HasConstraintName("FK_Grids_StudentEvents");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Grids)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Grids_Subjects");
            });

            modelBuilder.Entity<Presness>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LectureDate).HasColumnType("date");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Presness)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Presness_Events");
            });

            modelBuilder.Entity<PresnessInfo>(entity =>
            {
                entity.HasOne(d => d.Presness)
                    .WithMany(p => p.PresnessInfo)
                    .HasForeignKey(d => d.PresnessId)
                    .HasConstraintName("FK_PresnessInfo_Presness1");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.PresnessInfo)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_PresnessInfo_Students");
            });

            modelBuilder.Entity<Schools>(entity =>
            {
                entity.HasKey(e => e.SchoolId);

                entity.Property(e => e.CreatedBy).HasMaxLength(128);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Schools_User");
            });

            modelBuilder.Entity<StudentEvents>(entity =>
            {
                entity.HasKey(e => e.StudentEventId);

                entity.Property(e => e.CreatedBy).HasMaxLength(128);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.StudentEvents)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_StudentEvents_Events");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentEvents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentEvents_Students");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Adrress).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(128);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FatherName).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.GrandFatherName).HasMaxLength(50);

                entity.Property(e => e.MatherName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.SurName).HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Students_User");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.Property(e => e.CreatedBy).HasMaxLength(128);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.AcadimecYear)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.AcadimecYearId)
                    .HasConstraintName("FK_Subjects_AcadimacYears");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Years>(entity =>
            {
                entity.HasKey(e => e.YearId);

                entity.Property(e => e.CreatedBy).HasMaxLength(128);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
