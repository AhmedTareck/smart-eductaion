using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Management.Models
{
    public partial class Tranim_LearningContext : DbContext
    {
        public virtual DbSet<AcadimacYears> AcadimacYears { get; set; }
        public virtual DbSet<Ads> Ads { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<LectureImage> LectureImage { get; set; }
        public virtual DbSet<Lectures> Lectures { get; set; }
        public virtual DbSet<Shapters> Shapters { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public Tranim_LearningContext(DbContextOptions<Tranim_LearningContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"server=LAPTOP-DVJT5BST;database=Tranim_Learning;uid=Ahmed;pwd=35087124567Ahmed;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcadimacYears>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Ads>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnType("nchar(10)");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Events_Subjects");
            });

            modelBuilder.Entity<LectureImage>(entity =>
            {
                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.LectureImage)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_LectureImage_Lectures");
            });

            modelBuilder.Entity<Lectures>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Shapters)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.ShaptersId)
                    .HasConstraintName("FK_Lectures_Shapters");
            });

            modelBuilder.Entity<Shapters>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Shapters)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Shapters_Subjects");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.AcadimecYear)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.AcadimecYearId)
                    .HasConstraintName("FK_Subjects_AcadimacYears");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.LastLoginOn).HasColumnType("datetime");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.LoginTryAttemptDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });
        }
    }
}
