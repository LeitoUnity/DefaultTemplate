using Microsoft.EntityFrameworkCore.Migrations;

namespace Peluqueria.Migrations
{
    public partial class addlasthaircuttoclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Barbershop_BarbershopID",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_HairCut_Barbershop_BarbershopID",
                table: "HairCut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HairCut",
                table: "HairCut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barbershop",
                table: "Barbershop");

            migrationBuilder.RenameTable(
                name: "HairCut",
                newName: "HairCuts");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "Barbershop",
                newName: "Barbershops");

            migrationBuilder.RenameIndex(
                name: "IX_HairCut_BarbershopID",
                table: "HairCuts",
                newName: "IX_HairCuts_BarbershopID");

            migrationBuilder.RenameIndex(
                name: "IX_Client_BarbershopID",
                table: "Clients",
                newName: "IX_Clients_BarbershopID");

            migrationBuilder.AddColumn<int>(
                name: "HairCutID",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HairCuts",
                table: "HairCuts",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barbershops",
                table: "Barbershops",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_HairCutID",
                table: "Clients",
                column: "HairCutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Barbershops_BarbershopID",
                table: "Clients",
                column: "BarbershopID",
                principalTable: "Barbershops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_HairCuts_HairCutID",
                table: "Clients",
                column: "HairCutID",
                principalTable: "HairCuts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HairCuts_Barbershops_BarbershopID",
                table: "HairCuts",
                column: "BarbershopID",
                principalTable: "Barbershops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Barbershops_BarbershopID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_HairCuts_HairCutID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_HairCuts_Barbershops_BarbershopID",
                table: "HairCuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HairCuts",
                table: "HairCuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_HairCutID",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barbershops",
                table: "Barbershops");

            migrationBuilder.DropColumn(
                name: "HairCutID",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "HairCuts",
                newName: "HairCut");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameTable(
                name: "Barbershops",
                newName: "Barbershop");

            migrationBuilder.RenameIndex(
                name: "IX_HairCuts_BarbershopID",
                table: "HairCut",
                newName: "IX_HairCut_BarbershopID");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_BarbershopID",
                table: "Client",
                newName: "IX_Client_BarbershopID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HairCut",
                table: "HairCut",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barbershop",
                table: "Barbershop",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Barbershop_BarbershopID",
                table: "Client",
                column: "BarbershopID",
                principalTable: "Barbershop",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HairCut_Barbershop_BarbershopID",
                table: "HairCut",
                column: "BarbershopID",
                principalTable: "Barbershop",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
