using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MisTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Doctors_DiseaseId",
                table: "Diagnoses");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_DoctorId",
                table: "Diagnoses",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Doctors_DoctorId",
                table: "Diagnoses",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Doctors_DoctorId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_DoctorId",
                table: "Diagnoses");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Doctors_DiseaseId",
                table: "Diagnoses",
                column: "DiseaseId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
