using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Management.Models
{
    public partial class StudentTrackerContext : DbContext
    {
        public virtual DbSet<AcadimacYears> AcadimacYears { get; set; }
        public virtual DbSet<Degrees> Degrees { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<Grids> Grids { get; set; }
        public virtual DbSet<HomeWorcks> HomeWorcks { get; set; }
        public virtual DbSet<NotificationDelivary> NotificationDelivary { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Packeges> Packeges { get; set; }
        public virtual DbSet<Presness> Presness { get; set; }
        public virtual DbSet<PresnessInfo> PresnessInfo { get; set; }
        public virtual DbSet<Schools> Schools { get; set; }
        public virtual DbSet<Skedjule> Skedjule { get; set; }
        public virtual DbSet<StudentEvents> StudentEvents { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Years> Years { get; set; }

        public StudentTrackerContext(DbContextOptions<StudentTrackerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"server=41.208.71.78;database=StudentTracker;uid=AhmedTareck;pwd=35087124567Ahmed;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "AhmedTareck");

            modelBuilder.Entity<AcadimacYears>(entity =>
            {
                entity.HasKey(e => e.AcadimecYearId);

                entity.ToTable("AcadimacYears", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Degrees>(entity =>
            {
                entity.ToTable("Degrees", "dbo");

                entity.Property(e => e.CreatecdOn).HasColumnType("datetime");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Degrees)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Degrees_Users");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("Events", "dbo");

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

            modelBuilder.Entity<Exams>(entity =>
            {
                entity.HasKey(e => e.ExamId);

                entity.ToTable("Exams", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExamDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Exams_Events");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Exams_Subjects1");
            });

            modelBuilder.Entity<Grids>(entity =>
            {
                entity.HasKey(e => e.GridId);

                entity.ToTable("Grids", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Grids)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_Grids_Exams");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grids)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Grids_Students");
            });

            modelBuilder.Entity<HomeWorcks>(entity =>
            {
                entity.ToTable("HomeWorcks", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastDayDilavary).HasColumnType("date");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.HomeWorcks)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_HomeWorcks_Events");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.HomeWorcks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_HomeWorcks_Subjects");
            });

            modelBuilder.Entity<NotificationDelivary>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.NotificationDelivary)
                    .HasForeignKey(d => d.NotificationId)
                    .HasConstraintName("FK_NotificationDelivary_Notifications");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Packeges>(entity =>
            {
                entity.ToTable("Packeges", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StatrtDate).HasColumnType("date");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Packeges)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_Packeges_Schools");
            });

            modelBuilder.Entity<Presness>(entity =>
            {
                entity.ToTable("Presness", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LectureDate).HasColumnType("date");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Presness)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Presness_Events");
            });

            modelBuilder.Entity<PresnessInfo>(entity =>
            {
                entity.ToTable("PresnessInfo", "dbo");

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

                entity.ToTable("Schools", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Schools_User");
            });

            modelBuilder.Entity<Skedjule>(entity =>
            {
                entity.ToTable("Skedjule", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Skedjule)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Skedjule_Events");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Skedjule)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Skedjule_Subjects");
            });

            modelBuilder.Entity<StudentEvents>(entity =>
            {
                entity.HasKey(e => e.StudentEventId);

                entity.ToTable("StudentEvents", "dbo");

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

                entity.ToTable("Students", "dbo");

                entity.Property(e => e.Adrress).HasMaxLength(50);

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

                entity.ToTable("Subjects", "dbo");

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

                entity.ToTable("Users", "dbo");

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

            modelBuilder.Entity<Years>(entity =>
            {
                entity.HasKey(e => e.YearId);

                entity.ToTable("Years", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
