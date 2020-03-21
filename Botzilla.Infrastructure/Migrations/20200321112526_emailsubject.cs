using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Botzilla.Infrastructure.Migrations
{
    public partial class emailsubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "EmailContacts");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "EmailContacts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmailSubjectId",
                table: "EmailContacts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "EmailSubjects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSubjects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailContacts_EmailSubjectId",
                table: "EmailContacts",
                column: "EmailSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailContacts_EmailSubjects_EmailSubjectId",
                table: "EmailContacts",
                column: "EmailSubjectId",
                principalTable: "EmailSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailContacts_EmailSubjects_EmailSubjectId",
                table: "EmailContacts");

            migrationBuilder.DropTable(
                name: "EmailSubjects");

            migrationBuilder.DropIndex(
                name: "IX_EmailContacts_EmailSubjectId",
                table: "EmailContacts");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "EmailContacts");

            migrationBuilder.DropColumn(
                name: "EmailSubjectId",
                table: "EmailContacts");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "EmailContacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
