using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcessMe.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Employess",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employess_UserId",
                table: "Employess",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employess_Users_UserId",
                table: "Employess",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employess_Users_UserId",
                table: "Employess");

            migrationBuilder.DropIndex(
                name: "IX_Employess_UserId",
                table: "Employess");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employess");
        }
    }
}
