using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTester.Services.Migrations
{
    /// <inheritdoc />
    public partial class DBUpdated_PurchasedServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ServicesProvided");

            migrationBuilder.CreateTable(
                name: "PurchasedService",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serviceid = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedService", x => x.id);
                    table.ForeignKey(
                        name: "FK_PurchasedService_ServicesProvided_Serviceid",
                        column: x => x.Serviceid,
                        principalTable: "ServicesProvided",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedService_Serviceid",
                table: "PurchasedService",
                column: "Serviceid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedService");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ServicesProvided",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
