using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixBugInFragment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fragments_NewsPosts_Id",
                table: "Fragments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Fragments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Fragments_NewsPostId",
                table: "Fragments",
                column: "NewsPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fragments_NewsPosts_NewsPostId",
                table: "Fragments",
                column: "NewsPostId",
                principalTable: "NewsPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fragments_NewsPosts_NewsPostId",
                table: "Fragments");

            migrationBuilder.DropIndex(
                name: "IX_Fragments_NewsPostId",
                table: "Fragments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Fragments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fragments_NewsPosts_Id",
                table: "Fragments",
                column: "Id",
                principalTable: "NewsPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
