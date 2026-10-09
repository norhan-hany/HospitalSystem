using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalSystem.Migrations
{
    /// <inheritdoc />
    public partial class Doctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Doctors (Name, Image, SpecializationId)VALUES('Ahmed Ali', 'ahmed.jpg', 1),('Sara Mohamed', 'sara.jpg', 2),('Omar Hassan', 'omar.jpg', 3),('Mona Adel', 'mona.jpg', 4),('Youssef Ibrahim', 'youssef.jpg', 5),('Nour Khaled', 'nour.jpg', 6),('Karim Mostafa', 'karim.jpg', 7),('Hana Mahmoud', 'hana.jpg', 8),('Amr Samir', 'amr.jpg', 1),('Salma Ahmed', 'salma.jpg', 2),('Tarek Ali', 'tarek.jpg', 3),('Laila Hassan', 'laila.jpg', 4);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Doctors WHERE Name IN ('Ahmed Ali', 'Sara Mohamed', 'Omar Hassan', 'Mona Adel', 'Youssef Ibrahim', 'Nour Khaled', 'Karim Mostafa', 'Hana Mahmoud', 'Amr Samir', 'Salma Ahmed', 'Tarek Ali', 'Laila Hassan');");
        }
    }
}
