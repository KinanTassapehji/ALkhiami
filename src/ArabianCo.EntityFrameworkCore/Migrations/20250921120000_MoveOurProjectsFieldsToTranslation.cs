using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabianCo.Migrations
{
    /// <inheritdoc />
    public partial class MoveOurProjectsFieldsToTranslation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "OurProjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OurProjects");

            migrationBuilder.DropColumn(
                name: "System",
                table: "OurProjects");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OurProjectsTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "OurProjectsTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "System",
                table: "OurProjectsTranslations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "OurProjectsTranslations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OurProjectsTranslations");

            migrationBuilder.DropColumn(
                name: "System",
                table: "OurProjectsTranslations");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "OurProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OurProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "System",
                table: "OurProjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
