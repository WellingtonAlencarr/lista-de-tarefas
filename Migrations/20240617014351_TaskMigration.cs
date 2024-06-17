using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lista_de_Tarefas.Migrations
{
    /// <inheritdoc />
    public partial class TaskMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TB_TASK",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TASK_UserId",
                table: "TB_TASK",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TASK_TB_USER_UserId",
                table: "TB_TASK",
                column: "UserId",
                principalTable: "TB_USER",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TASK_TB_USER_UserId",
                table: "TB_TASK");

            migrationBuilder.DropIndex(
                name: "IX_TB_TASK_UserId",
                table: "TB_TASK");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TB_TASK");
        }
    }
}
