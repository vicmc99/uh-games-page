using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentrelationConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_NewsPosts_NewsPostId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ToReviewComments_NewsPosts_NewsPostId",
                table: "ToReviewComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToReviewComments",
                table: "ToReviewComments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ToReviewComments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToReviewComments",
                table: "ToReviewComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_NewsPosts_NewsPostId",
                table: "PostComments",
                column: "NewsPostId",
                principalTable: "NewsPosts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToReviewComments_NewsPosts_NewsPostId",
                table: "ToReviewComments",
                column: "NewsPostId",
                principalTable: "NewsPosts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_NewsPosts_NewsPostId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ToReviewComments_NewsPosts_NewsPostId",
                table: "ToReviewComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToReviewComments",
                table: "ToReviewComments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ToReviewComments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToReviewComments",
                table: "ToReviewComments",
                columns: new[] { "Id", "NewsPostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_NewsPosts_NewsPostId",
                table: "PostComments",
                column: "NewsPostId",
                principalTable: "NewsPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToReviewComments_NewsPosts_NewsPostId",
                table: "ToReviewComments",
                column: "NewsPostId",
                principalTable: "NewsPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
