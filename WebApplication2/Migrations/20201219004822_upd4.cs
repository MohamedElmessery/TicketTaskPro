using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class upd4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditlogs_Users_User_Id1",
                table: "Auditlogs");

            migrationBuilder.DropIndex(
                name: "IX_Auditlogs_User_Id1",
                table: "Auditlogs");

            migrationBuilder.DropColumn(
                name: "Tic_Id",
                table: "Auditlogs");

            migrationBuilder.DropColumn(
                name: "User_Id1",
                table: "Auditlogs");

            migrationBuilder.AlterColumn<int>(
                name: "User_Id",
                table: "Auditlogs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Auditlogs_User_Id",
                table: "Auditlogs",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditlogs_Users_User_Id",
                table: "Auditlogs",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditlogs_Users_User_Id",
                table: "Auditlogs");

            migrationBuilder.DropIndex(
                name: "IX_Auditlogs_User_Id",
                table: "Auditlogs");

            migrationBuilder.AlterColumn<int>(
                name: "User_Id",
                table: "Auditlogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tic_Id",
                table: "Auditlogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Id1",
                table: "Auditlogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auditlogs_User_Id1",
                table: "Auditlogs",
                column: "User_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditlogs_Users_User_Id1",
                table: "Auditlogs",
                column: "User_Id1",
                principalTable: "Users",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
