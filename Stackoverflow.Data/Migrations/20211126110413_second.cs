using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stackoverflow.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_User_UserID",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_UserID",
                table: "Question");

            migrationBuilder.CreateTable(
                name: "UserAnswer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AnswerID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAnswer_Answer_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnswer_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_AnswerID",
                table: "UserAnswer",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_UserID",
                table: "UserAnswer",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_Question_UserID",
                table: "Question",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_User_UserID",
                table: "Question",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
