using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Personells_PersonellId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_PrescriptionItems_PrescriptionItemsId",
                table: "Prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions");

            migrationBuilder.RenameTable(
                name: "Prescriptions",
                newName: "Prescription");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_PrescriptionItemsId",
                table: "Prescription",
                newName: "IX_Prescription_PrescriptionItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_PersonellId",
                table: "Prescription",
                newName: "IX_Prescription_PersonellId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescription",
                newName: "IX_Prescription_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescription",
                table: "Prescription",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patients_PatientId",
                table: "Prescription",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Personells_PersonellId",
                table: "Prescription",
                column: "PersonellId",
                principalTable: "Personells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_PrescriptionItems_PrescriptionItemsId",
                table: "Prescription",
                column: "PrescriptionItemsId",
                principalTable: "PrescriptionItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Patients_PatientId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Personells_PersonellId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_PrescriptionItems_PrescriptionItemsId",
                table: "Prescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescription",
                table: "Prescription");

            migrationBuilder.RenameTable(
                name: "Prescription",
                newName: "Prescriptions");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_PrescriptionItemsId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_PrescriptionItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_PersonellId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_PersonellId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientId",
                table: "Prescriptions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Personells_PersonellId",
                table: "Prescriptions",
                column: "PersonellId",
                principalTable: "Personells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_PrescriptionItems_PrescriptionItemsId",
                table: "Prescriptions",
                column: "PrescriptionItemsId",
                principalTable: "PrescriptionItems",
                principalColumn: "Id");
        }
    }
}
