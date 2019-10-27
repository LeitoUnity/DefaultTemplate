using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Peluqueria.Migrations
{
    public partial class Addhaircutandbarbershop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Client",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "BarbershopID",
                table: "Client",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Barbershop",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbershop", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HairCut",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BarbershopID = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairCut", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HairCut_Barbershop_BarbershopID",
                        column: x => x.BarbershopID,
                        principalTable: "Barbershop",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_BarbershopID",
                table: "Client",
                column: "BarbershopID");

            migrationBuilder.CreateIndex(
                name: "IX_HairCut_BarbershopID",
                table: "HairCut",
                column: "BarbershopID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Barbershop_BarbershopID",
                table: "Client",
                column: "BarbershopID",
                principalTable: "Barbershop",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Barbershop_BarbershopID",
                table: "Client");

            migrationBuilder.DropTable(
                name: "HairCut");

            migrationBuilder.DropTable(
                name: "Barbershop");

            migrationBuilder.DropIndex(
                name: "IX_Client_BarbershopID",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "BarbershopID",
                table: "Client");
        }
    }
}
