using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTester.Services.Migrations
{
    /// <inheritdoc />
    public partial class Database_UpdateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "PurchasedService",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedService_OrganizationId",
                table: "PurchasedService",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedService_Organizations_OrganizationId",
                table: "PurchasedService",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedService_Organizations_OrganizationId",
                table: "PurchasedService");

            migrationBuilder.DropIndex(
                name: "IX_PurchasedService_OrganizationId",
                table: "PurchasedService");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "PurchasedService");
        }
    }
}
