using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AVideoHost.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Titles_TitleId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_TitleId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Video");

            migrationBuilder.CreateTable(
                name: "TitleItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VideoId = table.Column<int>(nullable: false),
                    TitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitleItem_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleItem_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TitleItem_TitleId",
                table: "TitleItem",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleItem_VideoId",
                table: "TitleItem",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TitleItem");

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Video",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_TitleId",
                table: "Video",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Titles_TitleId",
                table: "Video",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
