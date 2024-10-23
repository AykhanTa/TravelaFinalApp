using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelaFinalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addBaseEntityTourCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TourCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TourCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "TourCategories",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TourCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TourCategories");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TourCategories");
        }
    }
}
