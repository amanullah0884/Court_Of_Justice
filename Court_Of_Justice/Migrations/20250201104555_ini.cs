using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Court_Of_Justice.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adalot",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adalot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaseSources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseSources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaseMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    AdalotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseMasters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CaseMasters_Adalot_AdalotId",
                        column: x => x.AdalotId,
                        principalTable: "Adalot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseMasters_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HieringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextHieringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hiering = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    CAseMasterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseDetails_CaseMasters_CAseMasterID",
                        column: x => x.CAseMasterID,
                        principalTable: "CaseMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseDetails_CAseMasterID",
                table: "CaseDetails",
                column: "CAseMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseMasters_AdalotId",
                table: "CaseMasters",
                column: "AdalotId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseMasters_SectionId",
                table: "CaseMasters",
                column: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseDetails");

            migrationBuilder.DropTable(
                name: "CaseSources");

            migrationBuilder.DropTable(
                name: "CaseMasters");

            migrationBuilder.DropTable(
                name: "Adalot");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
