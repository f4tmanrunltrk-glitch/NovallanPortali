using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovallanPortali.Data.Migrations
{
    /// <inheritdoc />
    public partial class VeritabaniKurulumu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ilanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResimYolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilanlar_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_KategoriId",
                table: "Ilanlar",
                column: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ilanlar");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
