using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartakHRM.UserService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Migration0909 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 8, 28, 0, 52, 26, 418, DateTimeKind.Utc).AddTicks(5858));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 8, 28, 0, 52, 26, 418, DateTimeKind.Utc).AddTicks(5474));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 28, 0, 52, 26, 418, DateTimeKind.Utc).AddTicks(5858),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 28, 0, 52, 26, 418, DateTimeKind.Utc).AddTicks(5474),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
