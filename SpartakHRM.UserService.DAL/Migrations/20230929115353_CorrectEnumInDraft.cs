using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartakHRM.UserService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CorrectEnumInDraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 29, 11, 53, 53, 801, DateTimeKind.Utc).AddTicks(8540),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 9, 27, 23, 31, 11, 329, DateTimeKind.Utc).AddTicks(4177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 29, 11, 53, 53, 801, DateTimeKind.Utc).AddTicks(8289),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 9, 27, 23, 31, 11, 329, DateTimeKind.Utc).AddTicks(3873));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 27, 23, 31, 11, 329, DateTimeKind.Utc).AddTicks(4177),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 9, 29, 11, 53, 53, 801, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 27, 23, 31, 11, 329, DateTimeKind.Utc).AddTicks(3873),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 9, 29, 11, 53, 53, 801, DateTimeKind.Utc).AddTicks(8289));
        }
    }
}
