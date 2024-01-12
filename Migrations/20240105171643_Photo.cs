using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAngular.Migrations
{
    /// <inheritdoc />
    public partial class Photo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "Hauseid",
                table: "Photo",
                newName: "HauseId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Changed",
                table: "Photo",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Photo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Photo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "Photo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Changed",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "HauseId",
                table: "Photo",
                newName: "Hauseid");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Photo",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
