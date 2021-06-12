using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Klinika.Migrations
{
    public partial class master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medical_specializations",
                columns: table => new
                {
                    IdSpecialization = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialization_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical_specializations", x => x.IdSpecialization);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Pesel = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    Maiden_name = table.Column<string>(nullable: true),
                    Forename = table.Column<string>(nullable: true),
                    Second_forename = table.Column<string>(nullable: true),
                    Sex = table.Column<bool>(nullable: false),
                    Date_of_birth = table.Column<DateTime>(nullable: false),
                    Date_of_death = table.Column<DateTime>(nullable: false),
                    City_of_birth = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Building_number = table.Column<string>(nullable: true),
                    Flat_number = table.Column<string>(nullable: true),
                    Phone_number = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Pesel);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    IdWorker = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(nullable: true),
                    Forename = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.IdWorker);
                    table.ForeignKey(
                        name: "FK_Workers_Roles_Role_id",
                        column: x => x.Role_id,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor_specializations",
                columns: table => new
                {
                    IdDoctor_specialization = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doctor_id = table.Column<int>(nullable: false),
                    Specialization_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor_specializations", x => x.IdDoctor_specialization);
                    table.ForeignKey(
                        name: "FK_Doctor_specializations_Workers_Doctor_id",
                        column: x => x.Doctor_id,
                        principalTable: "Workers",
                        principalColumn: "IdWorker",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_specializations_Medical_specializations_Specialization_id",
                        column: x => x.Specialization_id,
                        principalTable: "Medical_specializations",
                        principalColumn: "IdSpecialization",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    IdVisit = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visits_description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Compleated = table.Column<bool>(nullable: false),
                    Patient_id = table.Column<string>(nullable: true),
                    Doctor_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.IdVisit);
                    table.ForeignKey(
                        name: "FK_Visits_Workers_Doctor_id",
                        column: x => x.Doctor_id,
                        principalTable: "Workers",
                        principalColumn: "IdWorker",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_Patient_id",
                        column: x => x.Patient_id,
                        principalTable: "Patients",
                        principalColumn: "Pesel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Working_days",
                columns: table => new
                {
                    IdWorkingDay = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time_start = table.Column<DateTime>(nullable: false),
                    Time_end = table.Column<DateTime>(nullable: false),
                    Worker_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Working_days", x => x.IdWorkingDay);
                    table.ForeignKey(
                        name: "FK_Working_days_Workers_Worker_id",
                        column: x => x.Worker_id,
                        principalTable: "Workers",
                        principalColumn: "IdWorker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors_referals",
                columns: table => new
                {
                    IdReferal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Date_of_issue = table.Column<DateTime>(nullable: false),
                    Expiration_day = table.Column<DateTime>(nullable: false),
                    Visit_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors_referals", x => x.IdReferal);
                    table.ForeignKey(
                        name: "FK_Doctors_referals_Visits_Visit_id",
                        column: x => x.Visit_id,
                        principalTable: "Visits",
                        principalColumn: "IdVisit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    IdMedicine = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medicine_name = table.Column<string>(nullable: true),
                    Dosage = table.Column<string>(nullable: true),
                    Date_of_issue = table.Column<DateTime>(nullable: false),
                    Expiration_day = table.Column<DateTime>(nullable: false),
                    Visit_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.IdMedicine);
                    table.ForeignKey(
                        name: "FK_Medicines_Visits_Visit_id",
                        column: x => x.Visit_id,
                        principalTable: "Visits",
                        principalColumn: "IdVisit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_specializations_Doctor_id",
                table: "Doctor_specializations",
                column: "Doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_specializations_Specialization_id",
                table: "Doctor_specializations",
                column: "Specialization_id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_referals_Visit_id",
                table: "Doctors_referals",
                column: "Visit_id");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_Visit_id",
                table: "Medicines",
                column: "Visit_id");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_Doctor_id",
                table: "Visits",
                column: "Doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_Patient_id",
                table: "Visits",
                column: "Patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_Role_id",
                table: "Workers",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Working_days_Worker_id",
                table: "Working_days",
                column: "Worker_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor_specializations");

            migrationBuilder.DropTable(
                name: "Doctors_referals");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Working_days");

            migrationBuilder.DropTable(
                name: "Medical_specializations");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
