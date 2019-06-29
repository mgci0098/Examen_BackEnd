using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab3.Migrations
{
    public partial class AddUnigueCodTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodTracking",
                table: "Pachete",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pachete_CodTracking",
                table: "Pachete",
                column: "CodTracking",
                unique: true,
                filter: "[CodTracking] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pachete_CodTracking",
                table: "Pachete");

            migrationBuilder.AlterColumn<string>(
                name: "CodTracking",
                table: "Pachete",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
