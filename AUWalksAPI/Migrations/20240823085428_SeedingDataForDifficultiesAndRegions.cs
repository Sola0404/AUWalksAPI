using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AUWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesAndRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5cad5a8d-5696-4333-9ece-b998a1997934"), "Hard" },
                    { new Guid("883d7b93-a0a1-48ef-bdba-e52f5ce4febe"), "Easy" },
                    { new Guid("cc5fbb9d-5277-4f21-a84f-18276f71e593"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("9eb79079-fe2e-464d-a061-e391a9ca603b"), "CBR", "Canberra", "https://www.australia.com/content/australia/en_ca/places/canberra-and-surrounds/guide-to-canberra/_jcr_content/hero/desktop.adapt.1920.high.jpg" },
                    { new Guid("a8720e10-e420-450b-a636-2da229378f90"), "SYD", "Sydney", "https://www.australia.com/content/australia/en_ca/places/sydney-and-surrounds/guide-to-sydney/_jcr_content/hero/desktop.adapt.1920.high.jpg" },
                    { new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), "BNE", "Brisbane", "https://www.australia.com/content/australia/en_ca/places/brisbane-and-surrounds/guide-to-brisbane/_jcr_content/hero/desktop.adapt.1920.high.jpg" },
                    { new Guid("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"), "MEL", "Melbourne", "https://www.australia.com/content/australia/en_ca/places/melbourne-and-surrounds/guide-to-melbourne/_jcr_content/hero/desktop.adapt.1920.high.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5cad5a8d-5696-4333-9ece-b998a1997934"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("883d7b93-a0a1-48ef-bdba-e52f5ce4febe"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cc5fbb9d-5277-4f21-a84f-18276f71e593"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9eb79079-fe2e-464d-a061-e391a9ca603b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a8720e10-e420-450b-a636-2da229378f90"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"));
        }
    }
}
