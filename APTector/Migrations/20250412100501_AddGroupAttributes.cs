using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APTector.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Impact",
                table: "APTGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "APTGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "APTGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Impact",
                table: "APTGroups");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "APTGroups");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "APTGroups");
        }
    }
}
