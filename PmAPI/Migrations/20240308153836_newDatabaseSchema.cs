using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PmAPI.Migrations
{
    /// <inheritdoc />
    public partial class newDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetTicketId",
                table: "Links",
                newName: "Target");

            migrationBuilder.RenameColumn(
                name: "SourceTicketId",
                table: "Links",
                newName: "Source");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Target",
                table: "Links",
                newName: "TargetTicketId");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "Links",
                newName: "SourceTicketId");
        }
    }
}
