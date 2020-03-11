using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Botzilla.Infrastructure.Migrations
{
    public partial class newsMIgration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ActiveFrom",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ActiveTo",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateDeleted",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Articles",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Articles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Articles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveFrom",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ActiveTo",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ImageTitle",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Articles");
        }
    }
}
