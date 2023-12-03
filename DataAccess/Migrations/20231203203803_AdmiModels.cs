using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AdmiModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPosts_Journalists_JournalistId",
                table: "NewsPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPosts_Journalists_JournalistId",
                table: "NewsPosts",
                column: "JournalistId",
                principalTable: "Journalists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPosts_Journalists_JournalistId",
                table: "NewsPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPosts_Journalists_JournalistId",
                table: "NewsPosts",
                column: "JournalistId",
                principalTable: "Journalists",
                principalColumn: "Id");
        }
    }
}
