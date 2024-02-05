using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartakHRM.UserService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(6829),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(3062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(6498),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(2684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Offices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(7334),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(3532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(7047),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(3306));

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    DateTo = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserId",
                table: "Documents",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(3062),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(6829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(2684),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(6498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Offices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(3532),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(7334));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 14, 38, 57, 442, DateTimeKind.Utc).AddTicks(3306),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 11, 10, 21, 43, 53, 618, DateTimeKind.Utc).AddTicks(7047));
        }
    }
}
