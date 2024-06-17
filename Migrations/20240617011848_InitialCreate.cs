using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lista_de_Tarefas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_TASK",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "TB_USER",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TB_TASK",
                columns: new[] { "Id", "CreateDate", "Description", "ExpirationDate", "Status", "Title" },
                values: new object[] { 2L, "28.04.2024", "Apenas um teste da descricao", "29.04.2024", 0, "Teste" });

            migrationBuilder.InsertData(
                table: "TB_USER",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 2, "TesteUsuario@gmail.com", "TesteUsuario" });
        }
    }
}
