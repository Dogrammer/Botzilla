using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Botzilla.Infrastructure.Migrations
{
    public partial class countryseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ActiveFrom",
                table: "Countries",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ActiveTo",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserName",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Countries",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateDeleted",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Countries",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Countries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Countries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "Countries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Countries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveFrom",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ActiveTo",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedByUserName",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
