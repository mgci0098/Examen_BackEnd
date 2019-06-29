using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab3.Migrations
{
    public partial class AddPachete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pachete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaraOrigine = table.Column<string>(nullable: true),
                    DenumireExpeditor = table.Column<string>(nullable: true),
                    TaraDestinatie = table.Column<string>(nullable: true),
                    DenumireDestinatar = table.Column<string>(nullable: true),
                    AdresaDestinatar = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    CodTracking = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pachete", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pachete");
        }
    }
}
