using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhiteLagoon.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sqtf",
                table: "Villas",
                newName: "Sqft");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sqft",
                table: "Villas",
                newName: "Sqtf");
        }
    }
}
