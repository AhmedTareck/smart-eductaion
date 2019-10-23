﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Management.Models
{
    public partial class MailSystemContext : DbContext
    {
        public MailSystemContext()
        {
        }
        public MailSystemContext(DbContextOptions<MailSystemContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Conversations> Conversations { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<MessageType> MessageType { get; set; }
        public virtual DbSet<Participations> Participations { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"server=DESKTOP-4AI87L8\SQLEXPRESS;Database=Mail;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachments>(entity =>
            {
                entity.HasKey(e => e.AttachmentId);

                entity.HasIndex(e => e.ConversationId);

                entity.HasIndex(e => e.CreatedBy);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.ConversationId)
                    .HasConstraintName("FK_Attachments_Conversations");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Attachments_Users");
            });

            modelBuilder.Entity<Branches>(entity =>
            {
                entity.HasKey(e => e.BranchId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Conversations>(entity =>
            {
                entity.HasKey(e => e.ConversationId);

                entity.HasIndex(e => e.Creator);

                entity.Property(e => e.ConversationId)
                    .HasColumnName("ConversationID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.Conversation)
                    .WithOne(p => p.InverseConversation)
                    .HasForeignKey<Conversations>(d => d.ConversationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conversations_Conversations4");

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.Creator)
                    .HasConstraintName("FK_Conversations_Users");

                entity.HasOne(d => d.MessageType)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.MessageTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conversations_MessageType");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.HasIndex(e => e.AuthorId);

                entity.HasIndex(e => e.ConversationId);

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Messages_Users");

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ConversationId)
                    .HasConstraintName("FK_Messages_Conversations");
            });

            modelBuilder.Entity<MessageType>(entity =>
            {
                entity.HasIndex(e => e.CreatedBy)
                    .HasName("IX_AdTypes_CreatedBy");

                entity.HasIndex(e => e.ModifiedBy)
                    .HasName("IX_AdTypes_ModifiedBy");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MessageTypeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_AdTypes_Users");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.MessageTypeModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_AdTypes_Users1");
            });

            modelBuilder.Entity<Participations>(entity =>
            {
                entity.HasKey(e => new { e.ConversationId, e.UserId });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.Participations)
                    .HasForeignKey(d => d.ConversationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participations_Conversations");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Participations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participations_Users");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.HasIndex(e => e.MessageId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("FK_Transactions_Messages");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Transactions_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.BranchId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastLoginOn).HasColumnType("datetime");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginTryAttemptDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_Users_Branches");
            });
        }
    }
}