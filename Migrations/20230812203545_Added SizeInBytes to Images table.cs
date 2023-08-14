using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CZTrails.Migrations
{
    /// <inheritdoc />
    public partial class AddedSizeInBytestoImagestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FileSizeInBytes",
                table: "Images",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileSizeInBytes",
                table: "Images");
        }
    }
}
