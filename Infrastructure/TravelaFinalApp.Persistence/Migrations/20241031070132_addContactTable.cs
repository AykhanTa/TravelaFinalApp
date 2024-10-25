using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelaFinalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "553ef267-b5b4-4507-bd86-a65f3678a855", null, "Member", "MEMBER" },
                    { "ed1a79e7-cd61-4774-b8fb-301e29ea76c1", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7f8e1c71-a657-4626-b868-675d008e51d7", 0, "a73c5690-88ca-45e4-bc25-480c8e172666", "user@example.com", true, "Aykhan Taghizada", false, null, "USER@EXAMPLE.COM", "AYKHANT1", "AQAAAAIAAYagAAAAECKqllhSZHb36wlAGV0bbHCpmuL5Eug3HbpHqrHqJ9MWSSXnrwNPuWryicgsFndTtg==", null, false, "2936f453-bf3c-4c51-93a6-cd30fc0ed358", false, "aykhant1" },
                    { "be6209e7-751d-4d11-b188-62d1eeffd0aa", 0, "2f55b878-ca89-4a67-8c4b-09c693eb9396", "admin@example.com", true, "Ulvi Majid", false, null, "ADMIN@EXAMPLE.COM", "ULVIM9", "AQAAAAIAAYagAAAAEHXgGuEccUEBaiUOwEziPfEAh2FV5GINUW2kr/YcAgGUzm32M7mdTQac+QeKy8c0wQ==", null, false, "26ca7180-80de-4018-8551-e63aad155626", false, "ulvim9" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "553ef267-b5b4-4507-bd86-a65f3678a855", "7f8e1c71-a657-4626-b868-675d008e51d7" },
                    { "553ef267-b5b4-4507-bd86-a65f3678a855", "be6209e7-751d-4d11-b188-62d1eeffd0aa" },
                    { "ed1a79e7-cd61-4774-b8fb-301e29ea76c1", "be6209e7-751d-4d11-b188-62d1eeffd0aa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "553ef267-b5b4-4507-bd86-a65f3678a855", "7f8e1c71-a657-4626-b868-675d008e51d7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "553ef267-b5b4-4507-bd86-a65f3678a855", "be6209e7-751d-4d11-b188-62d1eeffd0aa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ed1a79e7-cd61-4774-b8fb-301e29ea76c1", "be6209e7-751d-4d11-b188-62d1eeffd0aa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "553ef267-b5b4-4507-bd86-a65f3678a855");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed1a79e7-cd61-4774-b8fb-301e29ea76c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f8e1c71-a657-4626-b868-675d008e51d7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be6209e7-751d-4d11-b188-62d1eeffd0aa");

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
        }
    }
}
