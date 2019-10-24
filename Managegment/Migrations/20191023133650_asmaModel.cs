using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Management.Migrations
{
    public partial class asmaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastSubject",
                table: "Conversations");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Conversations",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "Conversations",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Conversations_Creator",
                table: "Conversations",
                newName: "IX_Conversations_CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Conversations",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Conversations",
                newName: "Creator");

            migrationBuilder.RenameIndex(
                name: "IX_Conversations_CreatedBy",
                table: "Conversations",
                newName: "IX_Conversations_Creator");

            migrationBuilder.AddColumn<long>(
                name: "NationalId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastSubject",
                table: "Conversations",
                nullable: true);
        }
    }
}
