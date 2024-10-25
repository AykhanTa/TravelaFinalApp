using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelaFinalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addPackageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "05e2fdfe-64e2-4252-af74-a6885e820ca5", "032ced36-61a9-4d75-ba72-e52103c7bf33" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "63879464-316a-4d59-ab27-6a86364c046c", "a87be9a8-25e3-4221-85d5-fc4a428c9b13" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05e2fdfe-64e2-4252-af74-a6885e820ca5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63879464-316a-4d59-ab27-6a86364c046c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "032ced36-61a9-4d75-ba72-e52103c7bf33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a87be9a8-25e3-4221-85d5-fc4a428c9b13");

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    PersonCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    HotelDeals = table.Column<bool>(type: "bit", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageImages_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8323e845-401d-491d-84fe-976f1775d3eb", null, "Admin", "ADMIN" },
                    { "a8c73aa8-200c-4d3e-83ae-2936ccb43484", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5be32b09-65c0-4979-a3dd-7859ff8f6602", 0, "d68a8391-f570-44e2-8e5a-e0abe9e447eb", "user@example.com", true, "Aykhan Taghizada", false, null, "USER@EXAMPLE.COM", "AYKHANT1", "AQAAAAIAAYagAAAAEJ7QvlBPmuw4dHdJh0oSrCvZ4bfsnqhp3sL8BQmkd2iAu5NbYDZyiI26Lx0hpupxAw==", null, false, "480403c8-5e28-4dcb-8373-545b055e58f8", false, "aykhant1" },
                    { "d9c7f7d2-a72e-46bb-9d82-65cef9f19aea", 0, "16313db6-d8de-4dc9-80dc-8fbb79d6a2ce", "admin@example.com", true, "Ulvi Majid", false, null, "ADMIN@EXAMPLE.COM", "ULVI9", "AQAAAAIAAYagAAAAEPuGBa+ADgkZ7Qc4nbIqWF+8NHljQB0jSnFhotFFArxYPNNKNJnBsHAgjhusjA7aPw==", null, false, "23f45b1f-8ffa-4b13-b234-2325903da1bb", false, "ulvim9" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a8c73aa8-200c-4d3e-83ae-2936ccb43484", "5be32b09-65c0-4979-a3dd-7859ff8f6602" },
                    { "8323e845-401d-491d-84fe-976f1775d3eb", "d9c7f7d2-a72e-46bb-9d82-65cef9f19aea" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageImages_PackageId",
                table: "PackageImages",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_DestinationId",
                table: "Packages",
                column: "DestinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageImages");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a8c73aa8-200c-4d3e-83ae-2936ccb43484", "5be32b09-65c0-4979-a3dd-7859ff8f6602" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8323e845-401d-491d-84fe-976f1775d3eb", "d9c7f7d2-a72e-46bb-9d82-65cef9f19aea" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8323e845-401d-491d-84fe-976f1775d3eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8c73aa8-200c-4d3e-83ae-2936ccb43484");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5be32b09-65c0-4979-a3dd-7859ff8f6602");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9c7f7d2-a72e-46bb-9d82-65cef9f19aea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05e2fdfe-64e2-4252-af74-a6885e820ca5", null, "Admin", "ADMIN" },
                    { "63879464-316a-4d59-ab27-6a86364c046c", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "032ced36-61a9-4d75-ba72-e52103c7bf33", 0, "32a7b704-a022-4847-9397-5ed19e051cb9", "admin@example.com", true, "Ulvi Majid", false, null, "ADMIN@EXAMPLE.COM", "ULVI9", "AQAAAAIAAYagAAAAEHwAz3gfcuQ7r+BahvRw5JQX/NaZuM9r1YwdoluFcS12Zr8ONf2xV4YwdHojQG2NOg==", null, false, "9a12e51f-30c7-4947-b85d-9aa94113d671", false, "ulvim9" },
                    { "a87be9a8-25e3-4221-85d5-fc4a428c9b13", 0, "8f9ad08f-eca6-4bab-bf6e-6167df99b187", "user@example.com", true, "Aykhan Taghizada", false, null, "USER@EXAMPLE.COM", "AYKHANT1", "AQAAAAIAAYagAAAAEE+kOtvzfdcttvbM0J5z9Z5ensBP+W9RHAghqLIFRKxLLs+jNhKVR157iPLFe4LUZA==", null, false, "13207085-2337-40b9-9af1-2769d33307eb", false, "aykhant1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "05e2fdfe-64e2-4252-af74-a6885e820ca5", "032ced36-61a9-4d75-ba72-e52103c7bf33" },
                    { "63879464-316a-4d59-ab27-6a86364c046c", "a87be9a8-25e3-4221-85d5-fc4a428c9b13" }
                });
        }
    }
}
