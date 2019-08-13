using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StackExchangeParser.Migrations
{
    public partial class AddingText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeatureId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureId);
                });

            migrationBuilder.CreateTable(
                name: "FeatureToken",
                columns: table => new
                {
                    FeatureTokenId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(nullable: true),
                    FeatureId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureToken", x => x.FeatureTokenId);
                    table.ForeignKey(
                        name: "FK_FeatureToken_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeatureValue",
                columns: table => new
                {
                    FeatureId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<float>(nullable: false),
                    FeatureId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureValue", x => x.FeatureId);
                    table.ForeignKey(
                        name: "FK_FeatureValue_Features_FeatureId1",
                        column: x => x.FeatureId1,
                        principalTable: "Features",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureToken_FeatureId",
                table: "FeatureToken",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureValue_FeatureId1",
                table: "FeatureValue",
                column: "FeatureId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureToken");

            migrationBuilder.DropTable(
                name: "FeatureValue");

            migrationBuilder.DropTable(
                name: "Features");
        }
    }
}
