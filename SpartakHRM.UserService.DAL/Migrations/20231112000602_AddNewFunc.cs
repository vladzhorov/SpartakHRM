using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartakHRM.UserService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 0, 6, 2, 301, DateTimeKind.Utc).AddTicks(3604),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(6829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 0, 6, 2, 301, DateTimeKind.Utc).AddTicks(3206),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(6498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Offices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 0, 6, 2, 301, DateTimeKind.Utc).AddTicks(4131),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(7334));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 0, 6, 2, 301, DateTimeKind.Utc).AddTicks(3883),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(7047));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(6829),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 12, 0, 6, 2, 301, DateTimeKind.Utc).AddTicks(3604));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(6498),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 12, 0, 6, 2, 301, DateTimeKind.Utc).AddTicks(3206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Offices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(7334),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 12, 0, 6, 2, 301, DateTimeKind.Utc).AddTicks(4131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(7047),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 12, 0, 6, 2, 301, DateTimeKind.Utc).AddTicks(3883));
        }
    }
}
