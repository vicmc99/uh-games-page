using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class kmvFixBugsNewsdd4zz3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fragments",
                table: "Fragments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fragments",
                table: "Fragments",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fragments",
                table: "Fragments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fragments",
                table: "Fragments",
                columns: new[] { "Id", "NewsPostId" });
        }
    }
}
