using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dictionary.Migrations
{
    /// <inheritdoc />
    public partial class migrationtryagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    de = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_WordClasses_WordClassId",
                        column: x => x.WordClassId,
                        principalTable: "WordClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordProjects_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WordClasses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Noun" },
                    { 2, "Verb" },
                    { 3, "Adjective" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "WordClassId", "de", "no" },
                values: new object[,]
                {
                    { 1, 1, "Haus", "hus" },
                    { 2, 1, "Flasche", "flaske" },
                    { 3, 2, "gehen", "gå" },
                    { 4, 2, "sitzen", "sitte" },
                    { 5, 3, "blau", "blå" },
                    { 6, 3, "Klein", "liten" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordProjects_ProjectId",
                table: "WordProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WordProjects_WordId",
                table: "WordProjects",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordClassId",
                table: "Words",
                column: "WordClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordProjects");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "WordClasses");
        }
    }
}
