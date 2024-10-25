using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelaFinalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addGetAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "GetAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    PersonCount = table.Column<int>(type: "int", nullable: false),
                    KidsCount = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetAppointments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8635e84e-71d1-4746-bbfb-52e3b4338727", null, "Admin", "ADMIN" },
                    { "c5af045a-c2ed-468c-8e9d-3e8df8828083", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "57df8d70-9d7f-4b0f-8e94-22da9530de68", 0, "b764fd4a-ff40-4727-95ef-7628b11a47b9", "user@example.com", true, "Aykhan Taghizada", false, null, "USER@EXAMPLE.COM", "AYKHANT1", "AQAAAAIAAYagAAAAEEAZH6ANDpKMoHQrBbqcidtuslbR+qnPDIwqbt0ozxv/jHAFzkTStLXMv4KKvd37ww==", null, false, "dab762c7-0edf-4bcb-9d3b-c802f77d2034", false, "aykhant1" },
                    { "9849a375-cb85-4970-be10-b554712df1f7", 0, "0ae99ee9-e8b7-4d15-8504-68958d938684", "admin@example.com", true, "Ulvi Majid", false, null, "ADMIN@EXAMPLE.COM", "ULVIM9", "AQAAAAIAAYagAAAAEO81ldxpU0L/49gslO/zRa5DN01ogJji3bsOyCI6q0IzAZGIoN8NINCU6fPSd8SNvA==", null, false, "40551428-cdba-4666-a121-b7b79ca192ed", false, "ulvim9" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c5af045a-c2ed-468c-8e9d-3e8df8828083", "57df8d70-9d7f-4b0f-8e94-22da9530de68" },
                    { "8635e84e-71d1-4746-bbfb-52e3b4338727", "9849a375-cb85-4970-be10-b554712df1f7" },
                    { "c5af045a-c2ed-468c-8e9d-3e8df8828083", "9849a375-cb85-4970-be10-b554712df1f7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetAppointments");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c5af045a-c2ed-468c-8e9d-3e8df8828083", "57df8d70-9d7f-4b0f-8e94-22da9530de68" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8635e84e-71d1-4746-bbfb-52e3b4338727", "9849a375-cb85-4970-be10-b554712df1f7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c5af045a-c2ed-468c-8e9d-3e8df8828083", "9849a375-cb85-4970-be10-b554712df1f7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8635e84e-71d1-4746-bbfb-52e3b4338727");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5af045a-c2ed-468c-8e9d-3e8df8828083");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57df8d70-9d7f-4b0f-8e94-22da9530de68");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9849a375-cb85-4970-be10-b554712df1f7");

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
    }
}
