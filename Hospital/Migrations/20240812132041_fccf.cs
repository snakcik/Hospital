using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class fccf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Policlinics_PoliclinicId1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PoliclinicId1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Policlinics");

            migrationBuilder.DropColumn(
                name: "PoliclinicId1",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "PoliclinicId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PoliclinicId",
                table: "Patients",
                column: "PoliclinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Policlinics_PoliclinicId",
                table: "Patients",
                column: "PoliclinicId",
                principalTable: "Policlinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Policlinics_PoliclinicId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PoliclinicId",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Policlinics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PoliclinicId",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PoliclinicId1",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PoliclinicId1",
                table: "Patients",
                column: "PoliclinicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Policlinics_PoliclinicId1",
                table: "Patients",
                column: "PoliclinicId1",
                principalTable: "Policlinics",
                principalColumn: "Id");
        }
    }
}
