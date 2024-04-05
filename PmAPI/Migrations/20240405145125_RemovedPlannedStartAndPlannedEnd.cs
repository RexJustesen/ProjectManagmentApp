using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PmAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPlannedStartAndPlannedEnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannedEnd",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PlannedStartDate",
                table: "Tickets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlannedEnd",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlannedStartDate",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
