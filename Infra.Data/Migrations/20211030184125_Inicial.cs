using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListIndexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListIndexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Complete = table.Column<bool>(type: "bit", nullable: false),
                    ListIndexId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chores_ListIndexes_ListIndexId",
                        column: x => x.ListIndexId,
                        principalTable: "ListIndexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ListIndexes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Lista 01" });

            migrationBuilder.InsertData(
                table: "ListIndexes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Lista 02" });

            migrationBuilder.InsertData(
                table: "ListIndexes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Lista 03" });

            migrationBuilder.CreateIndex(
                name: "IX_Chores_ListIndexId",
                table: "Chores",
                column: "ListIndexId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chores");

            migrationBuilder.DropTable(
                name: "ListIndexes");
        }
    }
}
