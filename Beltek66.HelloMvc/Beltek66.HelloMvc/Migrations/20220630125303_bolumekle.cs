using Microsoft.EntityFrameworkCore.Migrations;

namespace Beltek66.HelloMvc.Migrations
{
    public partial class bolumekle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bolum",
                table: "tblOgretmenler");

            migrationBuilder.AddColumn<int>(
                name: "BolumId",
                table: "tblOgretmenler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bolumler",
                columns: table => new
                {
                    BolumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolumler", x => x.BolumId);
                });

            migrationBuilder.InsertData(
                table: "Bolumler",
                columns: new[] { "BolumId", "BolumAd" },
                values: new object[] { 1, "Bilgisayar Mühendisliği" });

            migrationBuilder.InsertData(
                table: "Bolumler",
                columns: new[] { "BolumId", "BolumAd" },
                values: new object[] { 2, "Elektrik ve Elektronik Mühendisliği" });

            migrationBuilder.CreateIndex(
                name: "IX_tblOgretmenler_BolumId",
                table: "tblOgretmenler",
                column: "BolumId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOgretmenler_Bolumler_BolumId",
                table: "tblOgretmenler",
                column: "BolumId",
                principalTable: "Bolumler",
                principalColumn: "BolumId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOgretmenler_Bolumler_BolumId",
                table: "tblOgretmenler");

            migrationBuilder.DropTable(
                name: "Bolumler");

            migrationBuilder.DropIndex(
                name: "IX_tblOgretmenler_BolumId",
                table: "tblOgretmenler");

            migrationBuilder.DropColumn(
                name: "BolumId",
                table: "tblOgretmenler");

            migrationBuilder.AddColumn<string>(
                name: "Bolum",
                table: "tblOgretmenler",
                type: "varchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "");
        }
    }
}
