using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lista_de_Tarefas.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TASK_TB_USER_UserId",
                table: "TB_TASK");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USER",
                table: "TB_USER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_TASK",
                table: "TB_TASK");

            migrationBuilder.RenameTable(
                name: "TB_USER",
                newName: "TB_USERS");

            migrationBuilder.RenameTable(
                name: "TB_TASK",
                newName: "TB_TASKS");

            migrationBuilder.RenameIndex(
                name: "IX_TB_TASK_UserId",
                table: "TB_TASKS",
                newName: "IX_TB_TASKS_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TB_USERS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TB_USERS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<DateTime>(
                name: "AcessDate",
                table: "TB_USERS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "TB_USERS",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "TB_USERS",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "TB_USERS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TB_TASKS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TB_TASKS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USERS",
                table: "TB_USERS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_TASKS",
                table: "TB_TASKS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TASKS_TB_USERS_UserId",
                table: "TB_TASKS",
                column: "UserId",
                principalTable: "TB_USERS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TASKS_TB_USERS_UserId",
                table: "TB_TASKS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USERS",
                table: "TB_USERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_TASKS",
                table: "TB_TASKS");

            migrationBuilder.DropColumn(
                name: "AcessDate",
                table: "TB_USERS");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "TB_USERS");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "TB_USERS");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "TB_USERS");

            migrationBuilder.RenameTable(
                name: "TB_USERS",
                newName: "TB_USER");

            migrationBuilder.RenameTable(
                name: "TB_TASKS",
                newName: "TB_TASK");

            migrationBuilder.RenameIndex(
                name: "IX_TB_TASKS_UserId",
                table: "TB_TASK",
                newName: "IX_TB_TASK_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TB_USER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TB_USER",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TB_TASK",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TB_TASK",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USER",
                table: "TB_USER",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_TASK",
                table: "TB_TASK",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TASK_TB_USER_UserId",
                table: "TB_TASK",
                column: "UserId",
                principalTable: "TB_USER",
                principalColumn: "Id");
        }
    }
}
