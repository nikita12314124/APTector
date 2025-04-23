using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APTector.Migrations
{
    /// <inheritdoc />
    public partial class AddSectorToAPTGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_APTGroups_APTGroupId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_APTGroupId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "APTGroupId",
                table: "Procedures");

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "APTGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sector",
                table: "APTGroups");

            migrationBuilder.AddColumn<int>(
                name: "APTGroupId",
                table: "Procedures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_APTGroupId",
                table: "Procedures",
                column: "APTGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_APTGroups_APTGroupId",
                table: "Procedures",
                column: "APTGroupId",
                principalTable: "APTGroups",
                principalColumn: "Id");
        }
    }
}
