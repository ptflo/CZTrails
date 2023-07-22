using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CZTrails.Migrations
{
    /// <inheritdoc />
    public partial class PridanoSPZpoledoRegiontabulky : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Spz",
                table: "Regions",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spz",
                table: "Regions");
        }
    }
}
