﻿// <auto-generated />
using Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Management.Migrations
{
    [DbContext(typeof(MailSystemContext))]
    [Migration("20191023133650_asmaModel")]
    partial class asmaModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Management.Models.AdTypes", b =>
                {
                    b.Property<long>("AdTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdTypeName");

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<short?>("Status");

                    b.HasKey("AdTypeId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("AdTypes");
                });

            modelBuilder.Entity("Management.Models.Attachments", b =>
                {
                    b.Property<long>("AttachmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("ContentFile");

                    b.Property<long?>("ConversationId");

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Extension");

                    b.Property<string>("FileName");

                    b.HasKey("AttachmentId");

                    b.HasIndex("ConversationId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Management.Models.Branches", b =>
                {
                    b.Property<long>("BranchId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("BranchLevel");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<short?>("Status");

                    b.HasKey("BranchId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Management.Models.Conversations", b =>
                {
                    b.Property<long>("ConversationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ConversationID");

                    b.Property<long?>("AdTypeId");

                    b.Property<string>("Body");

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsGroup");

                    b.Property<string>("Priolti");

                    b.Property<string>("Subject");

                    b.HasKey("ConversationId");

                    b.HasIndex("AdTypeId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("Management.Models.Messages", b =>
                {
                    b.Property<long>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MessageID");

                    b.Property<long?>("AuthorId");

                    b.Property<long?>("ConversationId");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Subject");

                    b.HasKey("MessageId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ConversationId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Management.Models.Participations", b =>
                {
                    b.Property<long>("ConversationId");

                    b.Property<long>("UserId")
                        .HasColumnName("UserID");

                    b.Property<bool?>("Archive");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsDelete");

                    b.Property<bool?>("IsFavorate");

                    b.Property<bool?>("IsRead");

                    b.HasKey("ConversationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Participations");
                });

            modelBuilder.Entity("Management.Models.Transactions", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TransactionID");

                    b.Property<bool?>("IsRead");

                    b.Property<long?>("MessageId");

                    b.Property<DateTime?>("TimeStamp")
                        .HasColumnType("datetime");

                    b.Property<long?>("UserId")
                        .HasColumnName("UserID");

                    b.HasKey("TransactionId");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Management.Models.Users", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("BranchId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<short>("Gender");

                    b.Property<DateTime?>("LastLoginOn")
                        .HasColumnType("datetime");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("LoginTryAttemptDate")
                        .HasColumnType("datetime");

                    b.Property<short>("LoginTryAttempts");

                    b.Property<long?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Phone")
                        .HasMaxLength(24);

                    b.Property<byte[]>("Photo");

                    b.Property<short>("Status");

                    b.Property<short?>("UserType");

                    b.HasKey("UserId");

                    b.HasIndex("BranchId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Management.Models.AdTypes", b =>
                {
                    b.HasOne("Management.Models.Users", "CreatedByNavigation")
                        .WithMany("AdTypesCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK_AdTypes_Users");

                    b.HasOne("Management.Models.Users", "ModifiedByNavigation")
                        .WithMany("AdTypesModifiedByNavigation")
                        .HasForeignKey("ModifiedBy")
                        .HasConstraintName("FK_AdTypes_Users1");
                });

            modelBuilder.Entity("Management.Models.Attachments", b =>
                {
                    b.HasOne("Management.Models.Conversations", "Conversation")
                        .WithMany("Attachments")
                        .HasForeignKey("ConversationId")
                        .HasConstraintName("FK_Attachments_Conversations");

                    b.HasOne("Management.Models.Users", "CreatedByNavigation")
                        .WithMany("Attachments")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK_Attachments_Users");
                });

            modelBuilder.Entity("Management.Models.Conversations", b =>
                {
                    b.HasOne("Management.Models.AdTypes", "AdType")
                        .WithMany("Conversations")
                        .HasForeignKey("AdTypeId")
                        .HasConstraintName("FK_Conversations_AdTypes");

                    b.HasOne("Management.Models.Users", "CreatorNavigation")
                        .WithMany("Conversations")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK_Conversations_Users");
                });

            modelBuilder.Entity("Management.Models.Messages", b =>
                {
                    b.HasOne("Management.Models.Users", "Author")
                        .WithMany("Messages")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_Messages_Users");

                    b.HasOne("Management.Models.Conversations", "Conversation")
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId")
                        .HasConstraintName("FK_Messages_Conversations");
                });

            modelBuilder.Entity("Management.Models.Participations", b =>
                {
                    b.HasOne("Management.Models.Conversations", "Conversation")
                        .WithMany("Participations")
                        .HasForeignKey("ConversationId")
                        .HasConstraintName("FK_Participations_Conversations");

                    b.HasOne("Management.Models.Users", "User")
                        .WithMany("Participations")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Participations_Users");
                });

            modelBuilder.Entity("Management.Models.Transactions", b =>
                {
                    b.HasOne("Management.Models.Messages", "Message")
                        .WithMany("Transactions")
                        .HasForeignKey("MessageId")
                        .HasConstraintName("FK_Transactions_Messages");

                    b.HasOne("Management.Models.Users", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Transactions_Users");
                });

            modelBuilder.Entity("Management.Models.Users", b =>
                {
                    b.HasOne("Management.Models.Branches", "Branch")
                        .WithMany("Users")
                        .HasForeignKey("BranchId")
                        .HasConstraintName("FK_Users_Branches");
                });
#pragma warning restore 612, 618
        }
    }
}
