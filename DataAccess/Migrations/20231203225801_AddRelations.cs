using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BanUserId",
                table: "SuperUsers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BanUserId",
                table: "Moderators",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BanUserId",
                table: "Journalists",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "BanUserId",
                table: "SuperUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BanUserId",
                table: "Moderators",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BanUserId",
                table: "Journalists",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
