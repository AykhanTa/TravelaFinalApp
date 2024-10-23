using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelaFinalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addUserSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
