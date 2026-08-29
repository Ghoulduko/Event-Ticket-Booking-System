using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddRowVersionToSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Seats",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Seats");
        }
    }
}
