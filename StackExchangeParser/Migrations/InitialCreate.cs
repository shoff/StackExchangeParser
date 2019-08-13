using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StackExchangeParser.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Class = table.Column<int>(nullable: false),
                    TagBased = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PostTypeId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: false),
                    OwnerDisplayName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    LastEditorDisplayName = table.Column<string>(nullable: true),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    LastActivityDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    FavoriteCount = table.Column<int>(nullable: false),
                    ClosedDate = table.Column<DateTime>(nullable: false),
                    LastEditorUserId = table.Column<long>(nullable: false),
                    AnswerCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    TagName = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    ExcerptPostId = table.Column<int>(nullable: false),
                    WikiPostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Reputation = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    LastAccessDate = table.Column<DateTime>(nullable: false),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: true),
                    Views = table.Column<int>(nullable: false),
                    UpVotes = table.Column<int>(nullable: false),
                    DownVotes = table.Column<int>(nullable: false),
                    AccountId = table.Column<long>(nullable: false),
                    ProfileImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PostId = table.Column<long>(nullable: false),
                    VoteTypeId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PostId = table.Column<long>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostHistories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PostHistoryTypeId = table.Column<int>(nullable: false),
                    PostId = table.Column<long>(nullable: false),
                    RevisionGUID = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostHistories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHistories_PostId",
                table: "PostHistories",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHistories_UserId",
                table: "PostHistories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostHistories");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
