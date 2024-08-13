using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5W5_EXO01.Migrations
{
    /// <inheritdoc />
    public partial class ResetDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM CatModel");

            migrationBuilder.InsertData(
                table: "CatModel",
                columns: new[] { "id", "name", "image" },
                values: new object[] { 1, "Cat 1", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzX9A_f_jDYExfolsAhVX7IgctPaA9qU0KUg&s" }
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
