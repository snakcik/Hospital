using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActivePasive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActivePasive",
                table: "Titles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActivePasive",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActivePasive",
                table: "Policlinics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActivePasive",
                table: "Personells",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActivePasive",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActivePasive",
                table: "Inventorys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActivePasive",
                table: "Departmens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivePasive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ActivePasive",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "ActivePasive",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ActivePasive",
                table: "Policlinics");

            migrationBuilder.DropColumn(
                name: "ActivePasive",
                table: "Personells");

            migrationBuilder.DropColumn(
                name: "ActivePasive",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ActivePasive",
                table: "Inventorys");

            migrationBuilder.DropColumn(
                name: "ActivePasive",
                table: "Departmens");
        }
    }
}
