using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SuperUsers_NickName_Password",
                table: "SuperUsers");

            migrationBuilder.DropIndex(
                name: "IX_Moderators_NickName_Password",
                table: "Moderators");

            migrationBuilder.DropIndex(
                name: "IX_Journalists_NickName_Password",
                table: "Journalists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SuperUsers_NickName_Password",
                table: "SuperUsers",
                columns: new[] { "NickName", "Password" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moderators_NickName_Password",
                table: "Moderators",
                columns: new[] { "NickName", "Password" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Journalists_NickName_Password",
                table: "Journalists",
                columns: new[] { "NickName", "Password" },
                unique: true);
        }
    }
}
