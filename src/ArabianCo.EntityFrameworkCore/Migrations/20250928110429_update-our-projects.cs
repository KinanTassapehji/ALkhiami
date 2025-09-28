using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabianCo.Migrations
{
    /// <inheritdoc />
    public partial class updateourprojects : Migration
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

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "OurProjectsTranslations",
                newName: "location");

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
                name: "System",
                table: "OurProjectsTranslations");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "OurProjectsTranslations",
                newName: "Description");

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
