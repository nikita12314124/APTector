using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APTector.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APTGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFinancial = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APTGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatrixName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tactics",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatrixId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tactics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tactics_Matrices_MatrixId",
                        column: x => x.MatrixId,
                        principalTable: "Matrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Techniques",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TacticId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Techniques_Tactics_TacticId",
                        column: x => x.TacticId,
                        principalTable: "Tactics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechniqueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    APTGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedures_APTGroups_APTGroupId",
                        column: x => x.APTGroupId,
                        principalTable: "APTGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Procedures_Techniques_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "Techniques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "APTGroupProcedures",
                columns: table => new
                {
                    APTGroupId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Probability = table.Column<double>(type: "float", nullable: false),
                    Criticality = table.Column<double>(type: "float", nullable: false),
                    BusinessImpact = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APTGroupProcedures", x => new { x.APTGroupId, x.ProcedureId });
                    table.ForeignKey(
                        name: "FK_APTGroupProcedures_APTGroups_APTGroupId",
                        column: x => x.APTGroupId,
                        principalTable: "APTGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APTGroupProcedures_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APTGroupProcedures_ProcedureId",
                table: "APTGroupProcedures",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_APTGroupId",
                table: "Procedures",
                column: "APTGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_TechniqueId",
                table: "Procedures",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Tactics_MatrixId",
                table: "Tactics",
                column: "MatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_Techniques_TacticId",
                table: "Techniques",
                column: "TacticId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APTGroupProcedures");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "APTGroups");

            migrationBuilder.DropTable(
                name: "Techniques");

            migrationBuilder.DropTable(
                name: "Tactics");

            migrationBuilder.DropTable(
                name: "Matrices");
        }
    }
}
