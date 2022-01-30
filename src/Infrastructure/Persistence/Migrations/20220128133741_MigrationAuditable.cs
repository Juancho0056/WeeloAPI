using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeeloApi.Infrastructure.Persistence.Migrations
{
    public partial class MigrationAuditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "PropertyTraces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PropertyTraces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "PropertyTraces",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "PropertyTraces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "PropertyTraces",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "PropertyTraces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Propertys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Propertys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Propertys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Propertys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Propertys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Propertys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "PropertyImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PropertyImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "PropertyImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "PropertyImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "PropertyImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "PropertyImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Owners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Owners",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Owners",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "PropertyTraces");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PropertyTraces");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "PropertyTraces");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PropertyTraces");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "PropertyTraces");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "PropertyTraces");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Propertys");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Owners");
        }
    }
}
