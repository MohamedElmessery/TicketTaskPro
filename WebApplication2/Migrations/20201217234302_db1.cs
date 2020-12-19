using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Tic_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tic_Name = table.Column<string>(nullable: true),
                    Creationdatetime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Laststatuschangesdatetime = table.Column<DateTime>(nullable: false),
                    Userassigned = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Tic_Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auditlogs",
                columns: table => new
                {
                    Aud_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tic_Id = table.Column<int>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    User_Id = table.Column<int>(nullable: false),
                    Datetime = table.Column<DateTime>(nullable: false),
                    User_Id1 = table.Column<int>(nullable: true),
                    TicketTic_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditlogs", x => x.Aud_id);
                    table.ForeignKey(
                        name: "FK_Auditlogs_Tickets_TicketTic_Id",
                        column: x => x.TicketTic_Id,
                        principalTable: "Tickets",
                        principalColumn: "Tic_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auditlogs_Users_User_Id1",
                        column: x => x.User_Id1,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditlogs_TicketTic_Id",
                table: "Auditlogs",
                column: "TicketTic_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Auditlogs_User_Id1",
                table: "Auditlogs",
                column: "User_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditlogs");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
