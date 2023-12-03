using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSuperUsersTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BanUsers_SuperUser_SuperUserId",
                table: "BanUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SuperUser_Users_UserId",
                table: "SuperUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperUser",
                table: "SuperUser");

            migrationBuilder.RenameTable(
                name: "SuperUser",
                newName: "SuperUsers");

            migrationBuilder.RenameIndex(
                name: "IX_SuperUser_UserId",
                table: "SuperUsers",
                newName: "IX_SuperUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SuperUser_NickName_Password",
                table: "SuperUsers",
                newName: "IX_SuperUsers_NickName_Password");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperUsers",
                table: "SuperUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BanUsers_SuperUsers_SuperUserId",
                table: "BanUsers",
                column: "SuperUserId",
                principalTable: "SuperUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SuperUsers_Users_UserId",
                table: "SuperUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BanUsers_SuperUsers_SuperUserId",
                table: "BanUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SuperUsers_Users_UserId",
                table: "SuperUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperUsers",
                table: "SuperUsers");

            migrationBuilder.RenameTable(
                name: "SuperUsers",
                newName: "SuperUser");

            migrationBuilder.RenameIndex(
                name: "IX_SuperUsers_UserId",
                table: "SuperUser",
                newName: "IX_SuperUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SuperUsers_NickName_Password",
                table: "SuperUser",
                newName: "IX_SuperUser_NickName_Password");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperUser",
                table: "SuperUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BanUsers_SuperUser_SuperUserId",
                table: "BanUsers",
                column: "SuperUserId",
                principalTable: "SuperUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SuperUser_Users_UserId",
                table: "SuperUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
