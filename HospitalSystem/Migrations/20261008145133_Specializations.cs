using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalSystem.Migrations
{
    /// <inheritdoc />
    public partial class Specializations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Specializations (Name)VALUES('Cardiology'),('Pediatrics'),('Dentistry'),('Neurology'),('Dermatology'),('Orthopedics'),('Ophthalmology'),('Gynecology');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Specializations WHERE Name IN ('Cardiology', 'Pediatrics', 'Dentistry', 'Neurology', 'Dermatology', 'Orthopedics', 'Ophthalmology', 'Gynecology');");
        }
    }
}
