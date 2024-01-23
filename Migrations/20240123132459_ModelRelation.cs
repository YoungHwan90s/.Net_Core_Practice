using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunNetCoreWeb.Migrations
{
    public partial class ModelRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Clubs_ClubId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Races_RaceId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ClubId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_RaceId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Races_AddressId",
                table: "Races",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Addresses_AddressId",
                table: "Races",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Addresses_AddressId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_AddressId",
                table: "Races");

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ClubId",
                table: "Addresses",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_RaceId",
                table: "Addresses",
                column: "RaceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Clubs_ClubId",
                table: "Addresses",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Races_RaceId",
                table: "Addresses",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");
        }
    }
}
