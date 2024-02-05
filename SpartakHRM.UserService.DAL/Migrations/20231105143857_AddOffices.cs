using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartakHRM.UserService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddOffices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(3062),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 9, 29, 11, 53, 53, 801, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(2684),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 9, 29, 11, 53, 53, 801, DateTimeKind.Utc).AddTicks(8289));

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(3306)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(3532))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 29, 11, 53, 53, 801, DateTimeKind.Utc).AddTicks(8540),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(3062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 29, 11, 53, 53, 801, DateTimeKind.Utc).AddTicks(8289),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(2684));
        }
    }
}
