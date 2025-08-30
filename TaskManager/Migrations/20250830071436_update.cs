using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AssignTasks_TaskId",
                table: "AssignTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignTasks_Tasklists_TaskId",
                table: "AssignTasks",
                column: "TaskId",
                principalTable: "Tasklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignTasks_Tasklists_TaskId",
                table: "AssignTasks");

            migrationBuilder.DropIndex(
                name: "IX_AssignTasks_TaskId",
                table: "AssignTasks");
        }
    }
}
