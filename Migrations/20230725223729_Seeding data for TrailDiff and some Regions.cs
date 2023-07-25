using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CZTrails.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforTrailDiffandsomeRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "Spz" },
                values: new object[,]
                {
                    { new Guid("063f3cfb-f233-4422-bf9b-af3586f33c7e"), "PHA", "Hlavní město Praha", "A" },
                    { new Guid("13ec54c1-e829-4dda-93aa-f8bb014730f2"), "JHČ", "Jihočeský kraj", "C" },
                    { new Guid("41872f28-4c69-427e-b726-754e929f2b86"), "PLK", "Plzeňský kraj", "P" },
                    { new Guid("6c79963a-414b-4211-8b17-80580786b447"), "STČ", "Středočeský kraj", "S" },
                    { new Guid("efc5a27a-e530-4d20-9f4b-448dac386eb6"), "KVK", "Karlovarský kraj", "K" }
                });

            migrationBuilder.InsertData(
                table: "TrailDifficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("76f6f7e4-de7d-4a91-91e0-6c996f4a3bfc"), "Lehká" },
                    { new Guid("f391738c-228e-45a0-938d-94f736cdbc96"), "Střední" },
                    { new Guid("f7bc4218-d58c-4d81-be87-6d0635f85c00"), "Těžká" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("063f3cfb-f233-4422-bf9b-af3586f33c7e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("13ec54c1-e829-4dda-93aa-f8bb014730f2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("41872f28-4c69-427e-b726-754e929f2b86"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6c79963a-414b-4211-8b17-80580786b447"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("efc5a27a-e530-4d20-9f4b-448dac386eb6"));

            migrationBuilder.DeleteData(
                table: "TrailDifficulties",
                keyColumn: "Id",
                keyValue: new Guid("76f6f7e4-de7d-4a91-91e0-6c996f4a3bfc"));

            migrationBuilder.DeleteData(
                table: "TrailDifficulties",
                keyColumn: "Id",
                keyValue: new Guid("f391738c-228e-45a0-938d-94f736cdbc96"));

            migrationBuilder.DeleteData(
                table: "TrailDifficulties",
                keyColumn: "Id",
                keyValue: new Guid("f7bc4218-d58c-4d81-be87-6d0635f85c00"));
        }
    }
}
