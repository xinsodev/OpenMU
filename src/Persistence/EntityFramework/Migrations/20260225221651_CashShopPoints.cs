using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUnique.OpenMU.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CashShopPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GoblinPoints",
                schema: "data",
                table: "Account",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WCoinC",
                schema: "data",
                table: "Account",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WCoinP",
                schema: "data",
                table: "Account",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoblinPoints",
                schema: "data",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "WCoinC",
                schema: "data",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "WCoinP",
                schema: "data",
                table: "Account");
        }
    }
}
