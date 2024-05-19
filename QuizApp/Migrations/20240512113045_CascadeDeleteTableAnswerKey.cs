using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteTableAnswerKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswersKeys_Answers_AnswerId",
                table: "AnswersKeys");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersKeys_Answers_AnswerId",
                table: "AnswersKeys",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswersKeys_Answers_AnswerId",
                table: "AnswersKeys");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersKeys_Answers_AnswerId",
                table: "AnswersKeys",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");
        }
    }
}
