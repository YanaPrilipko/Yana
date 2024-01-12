using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAngular.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hauseid",
                table: "Order",
                newName: "HauseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HauseId",
                table: "Order",
                newName: "Hauseid");
        }
    }
}
