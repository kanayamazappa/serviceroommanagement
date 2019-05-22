using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class FirtsCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    IdRoom = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    AlterDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.IdRoom);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    IdSchedule = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.IdSchedule);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Administrator = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Managements",
                columns: table => new
                {
                    IdManagement = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdRoom = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managements", x => x.IdManagement);
                    table.ForeignKey(
                        name: "FK_Managements_Rooms_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "IdRoom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Managements_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementSchedules",
                columns: table => new
                {
                    IdManagement = table.Column<int>(nullable: false),
                    IdSchedule = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementSchedules", x => new { x.IdManagement, x.IdSchedule });
                    table.ForeignKey(
                        name: "FK_ManagementSchedules_Managements_IdManagement",
                        column: x => x.IdManagement,
                        principalTable: "Managements",
                        principalColumn: "IdManagement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementSchedules_Schedules_IdSchedule",
                        column: x => x.IdSchedule,
                        principalTable: "Schedules",
                        principalColumn: "IdSchedule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Managements_IdRoom",
                table: "Managements",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Managements_IdUser",
                table: "Managements",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementSchedules_IdSchedule",
                table: "ManagementSchedules",
                column: "IdSchedule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagementSchedules");

            migrationBuilder.DropTable(
                name: "Managements");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
