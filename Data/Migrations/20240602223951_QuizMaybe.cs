using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuizMaybe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Surveys_SurveyId",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FeedbackAnswer");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "Feedbacks",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_SurveyId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_QuestionId");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Feedbacks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Answer",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Question_QuestionId",
                table: "Feedbacks",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Question_QuestionId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answer");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Feedbacks",
                newName: "SurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_QuestionId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_SurveyId");

            migrationBuilder.CreateTable(
                name: "FeedbackAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    FeedbackId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedbackAnswer_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackAnswer_FeedbackId",
                table: "FeedbackAnswer",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackAnswer_QuestionId",
                table: "FeedbackAnswer",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Surveys_SurveyId",
                table: "Feedbacks",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
