using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRentCar.Migrations
{
    /// <inheritdoc />
    public partial class AddAllCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admindata",
                columns: table => new
                {
                    LoginAdmin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admindata", x => x.LoginAdmin);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    LNumberTb = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeGearBoxTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfFuelTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceTb = table.Column<int>(type: "int", nullable: false),
                    EngineCapalityTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachinebodyTypeTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhostTypeTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPassagerCarsTb = table.Column<int>(type: "int", nullable: false),
                    StatusTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachinebodyTypeCrossoverTb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhostTypeCrossoverTb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachinebodytypeElectro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeFuelElectro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachinebodytypeMinivan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberofpassagercarsForMinivan = table.Column<int>(type: "int", nullable: true),
                    MachinebodyTypeSportTb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineCapacitySportCarTb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.LNumberTb);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    СustomerFullNameTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _AddreessTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCustomerTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatePasswordTb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateLoginTb = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentCars",
                columns: table => new
                {
                    RentId = table.Column<int>(type: "int", nullable: false),
                    Car = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReturnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Fees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentCars", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_RentCars_Users_User",
                        column: x => x.User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentCars_cars_Car",
                        column: x => x.Car,
                        principalTable: "cars",
                        principalColumn: "LNumberTb",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnsCars",
                columns: table => new
                {
                    RentId = table.Column<int>(type: "int", nullable: false),
                    Car = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Delay = table.Column<int>(type: "int", nullable: false),
                    Fine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnsCars", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_ReturnsCars_Users_User",
                        column: x => x.User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnsCars_cars_Car",
                        column: x => x.Car,
                        principalTable: "cars",
                        principalColumn: "LNumberTb",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentCars_Car",
                table: "RentCars",
                column: "Car",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentCars_User",
                table: "RentCars",
                column: "User",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsCars_Car",
                table: "ReturnsCars",
                column: "Car",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsCars_User",
                table: "ReturnsCars",
                column: "User",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admindata");

            migrationBuilder.DropTable(
                name: "RentCars");

            migrationBuilder.DropTable(
                name: "ReturnsCars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "cars");
        }
    }
}
