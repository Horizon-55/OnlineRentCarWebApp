using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRentCar.Migrations
{
    /// <inheritdoc />
    public partial class ChangePkFkRentReturns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReturnsCars_User",
                table: "ReturnsCars");

            migrationBuilder.DropIndex(
                name: "IX_RentCars_User",
                table: "RentCars");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsCars_User",
                table: "ReturnsCars",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_RentCars_User",
                table: "RentCars",
                column: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReturnsCars_User",
                table: "ReturnsCars");

            migrationBuilder.DropIndex(
                name: "IX_RentCars_User",
                table: "RentCars");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsCars_User",
                table: "ReturnsCars",
                column: "User",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentCars_User",
                table: "RentCars",
                column: "User",
                unique: true);
        }
    }
}
