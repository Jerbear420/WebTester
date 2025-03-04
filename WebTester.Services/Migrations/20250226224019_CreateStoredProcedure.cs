using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTester.Services.Migrations
{
    /// <inheritdoc />
    public partial class CreateStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
                CREATE PROCEDURE GetTicketNotesByTicketId
                    @TicketID INT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    
                    -- Securely query the TicketNotes table
                    SELECT *
                    FROM TicketNotes
                    WHERE TicketId = @TicketID;
                END;
            ";

            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetTicketNotesByTicketId;");
        }
    }
}
