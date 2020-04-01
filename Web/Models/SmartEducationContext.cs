using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web.Models
{
    public partial class SmartEducationContext : DbContext
    {
        public virtual DbSet<AcadimacYears> AcadimacYears { get; set; }
        public virtual DbSet<Ads> Ads { get; set; }
        public virtual DbSet<AdsFiles> AdsFiles { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<LectureFiles> LectureFiles { get; set; }
        public virtual DbSet<Lectures> Lectures { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Municipalitys> Municipalitys { get; set; }
        public virtual DbSet<PermissionGroup> PermissionGroup { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Schools> Schools { get; set; }
        public virtual DbSet<Shapters> Shapters { get; set; }
        public virtual DbSet<StudentAnswer> StudentAnswer { get; set; }
        public virtual DbSet<StudentExam> StudentExam { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public SmartEducationContext(DbContextOptions<SmartEducationContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"server=localhost;database=SmartEducation;uid=sa;pwd=Pass123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcadimacYears>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Ads>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<AdsFiles>(entity =>
            {
                entity.HasOne(d => d.Ads)
                    .WithMany(p => p.AdsFiles)
                    .HasForeignKey(d => d.AdsId)
                    .HasConstraintName("FK_AdsFiles_Ads");
            });

            modelBuilder.Entity<Answers>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExamAnswers).HasMaxLength(150);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Answers_Questions");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Discreptions).HasMaxLength(150);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Events_Subjects");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Events_Users");
            });

            modelBuilder.Entity<Exams>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Exams_Events");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Exams_Subjects");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.State).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<LectureFiles>(entity =>
            {
                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.LectureFiles)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_LectureFiles_Lectures");
            });

            modelBuilder.Entity<Lectures>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Shapters)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.ShaptersId)
                    .HasConstraintName("FK_Lectures_Shapters");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.Property(e => e.Coordinates).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Locations_Locations");
            });

            modelBuilder.Entity<Municipalitys>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressDiscreption).HasMaxLength(150);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Discreption).HasMaxLength(150);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Municipalitys)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Municipalitys_Locations");

                entity.HasOne(d => d.Responsible)
                    .WithMany(p => p.Municipalitys)
                    .HasForeignKey(d => d.ResponsibleId)
                    .HasConstraintName("FK_Municipalitys_Users");
            });

            modelBuilder.Entity<PermissionGroup>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.State).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.PermissionGroup)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_PermissionGroup_Groups");

                entity.HasOne(d => d.Permissioin)
                    .WithMany(p => p.PermissionGroup)
                    .HasForeignKey(d => d.PermissioinId)
                    .HasConstraintName("FK_PermissionGroup_Permissions");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.State).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Question).HasMaxLength(250);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_Questions_Exams");
            });

            modelBuilder.Entity<Schools>(entity =>
            {
                entity.Property(e => e.AddressDiscreption).HasMaxLength(150);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Schools_Locations");

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.MunicipalityId)
                    .HasConstraintName("FK_Schools_Municipalitys");

                entity.HasOne(d => d.Responsible)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.ResponsibleId)
                    .HasConstraintName("FK_Schools_Users");
            });

            modelBuilder.Entity<Shapters>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Shapters)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Shapters_Events");
            });

            modelBuilder.Entity<StudentAnswer>(entity =>
            {
                entity.HasOne(d => d.Ansewr)
                    .WithMany(p => p.StudentAnswer)
                    .HasForeignKey(d => d.AnsewrId)
                    .HasConstraintName("FK_StudentAnswer_Answers");

                entity.HasOne(d => d.StudentExam)
                    .WithMany(p => p.StudentAnswer)
                    .HasForeignKey(d => d.StudentExamId)
                    .HasConstraintName("FK_StudentAnswer_StudentExam");
            });

            modelBuilder.Entity<StudentExam>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.StudentExam)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_StudentExam_Exams");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentExam)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentExam_Students");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.Adrress).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FatherName).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.GrandFatherName).HasMaxLength(50);

                entity.Property(e => e.MatherName).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Nid)
                    .HasColumnName("NID")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.SurName).HasMaxLength(50);

                entity.HasOne(d => d.AcadimecYear)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AcadimecYearId)
                    .HasConstraintName("FK_Students_AcadimacYears");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_Students_Schools");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Discreptions).HasMaxLength(150);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.AcadimecYear)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.AcadimecYearId)
                    .HasConstraintName("FK_Subjects_AcadimacYears");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.LastLoginOn).HasColumnType("datetime");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.LoginTryAttemptDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.Property(e => e.State).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserType).HasDefaultValueSql("((2))");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Users_Group");
            });
        }
    }
}
