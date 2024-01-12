using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAngular.Migrations
{
    /// <inheritdoc />
    public partial class NowOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HauseId",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HauseId",
                table: "Order",
                type: "integer",
                nullable: true);
        }
    }
}
