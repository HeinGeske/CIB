using Microsoft.EntityFrameworkCore.Migrations;

namespace Phonebook.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPhonebook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPhonebook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Number = table.Column<string>(maxLength: 20, nullable: false),
                    PhonebookId = table.Column<int>(nullable: false),
                    PhonebookEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEntry_tblPhonebook_PhonebookEntityId",
                        column: x => x.PhonebookEntityId,
                        principalTable: "tblPhonebook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEntry_Name",
                table: "tblEntry",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_tblEntry_PhonebookEntityId",
                table: "tblEntry",
                column: "PhonebookEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEntry");

            migrationBuilder.DropTable(
                name: "tblPhonebook");
        }
    }
}
