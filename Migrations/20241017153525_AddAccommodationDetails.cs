using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheMaxieInn.Migrations
{
    /// <inheritdoc />
    public partial class AddAccommodationDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccommodationDetails",
                table: "DogReservation",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccommodationDetails",
                table: "DogReservation");
        }
    }
}
