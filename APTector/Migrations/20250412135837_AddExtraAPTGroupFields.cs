using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APTector.Migrations
{
    /// <inheritdoc />
    public partial class AddExtraAPTGroupFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveSince",
                table: "APTGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aliases",
                table: "APTGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "AttributionConfidence",
                table: "APTGroups",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeographicalFocus",
                table: "APTGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Motivation",
                table: "APTGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NotableCampaigns",
                table: "APTGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TargetIndustries",
                table: "APTGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ThreatLevel",
                table: "APTGroups",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveSince",
                table: "APTGroups");

            migrationBuilder.DropColumn(
                name: "Aliases",
                table: "APTGroups");

            migrationBuilder.DropColumn(
                name: "AttributionConfidence",
                table: "APTGroups");

            migrationBuilder.DropColumn(
                name: "GeographicalFocus",
                table: "APTGroups");

            migrationBuilder.DropColumn(
                name: "Motivation",
                table: "APTGroups");

            migrationBuilder.DropColumn(
                name: "NotableCampaigns",
                table: "APTGroups");

            migrationBuilder.DropColumn(
                name: "TargetIndustries",
                table: "APTGroups");

            migrationBuilder.DropColumn(
                name: "ThreatLevel",
                table: "APTGroups");
        }
    }
}
