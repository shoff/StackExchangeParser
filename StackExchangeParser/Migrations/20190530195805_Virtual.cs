using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StackExchangeParser.Migrations
{
    public partial class Virtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Users_UserId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Posts_PostId",
                table: "Votes");

            migrationBuilder.AlterColumn<long>(
                name: "PostId",
                table: "Votes",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ExcerptPostId",
                table: "Tags",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OwnerUserId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "LastEditorUserId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastEditDate",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosedDate",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Badges",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ExcerptPostId",
                table: "Tags",
                column: "ExcerptPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_OwnerUserId",
                table: "Posts",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_Users_UserId",
                table: "Badges",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_OwnerUserId",
                table: "Posts",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_ExcerptPostId",
                table: "Tags",
                column: "ExcerptPostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Posts_PostId",
                table: "Votes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Users_UserId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_OwnerUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_ExcerptPostId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Posts_PostId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ExcerptPostId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Posts_OwnerUserId",
                table: "Posts");

            migrationBuilder.AlterColumn<long>(
                name: "PostId",
                table: "Votes",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExcerptPostId",
                table: "Tags",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerUserId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LastEditorUserId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastEditDate",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosedDate",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Badges",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_Users_UserId",
                table: "Badges",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Posts_PostId",
                table: "Votes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
