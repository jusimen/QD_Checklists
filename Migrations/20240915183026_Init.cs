using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QD_Checklists.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Typologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checklists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<string>(type: "TEXT", nullable: false),
                    ComponentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    AreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DivisionId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamLeaderId = table.Column<int>(type: "INTEGER", nullable: true),
                    TypologyId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegionCountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Regulations = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckerId = table.Column<int>(type: "INTEGER", nullable: true),
                    ApproverId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientManagerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checklists_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_Regions_RegionCountryId",
                        column: x => x.RegionCountryId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_Typologies_TypologyId",
                        column: x => x.TypologyId,
                        principalTable: "Typologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_Users_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checklists_Users_CheckerId",
                        column: x => x.CheckerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checklists_Users_ClientManagerId",
                        column: x => x.ClientManagerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checklists_Users_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_Users_TeamLeaderId",
                        column: x => x.TeamLeaderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChecklistTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: true),
                    ChecklistDTOId = table.Column<int>(type: "INTEGER", nullable: true),
                    ChecklistTaskDTOId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistTasks_ChecklistTasks_ChecklistTaskDTOId",
                        column: x => x.ChecklistTaskDTOId,
                        principalTable: "ChecklistTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChecklistTasks_Checklists_ChecklistDTOId",
                        column: x => x.ChecklistDTOId,
                        principalTable: "Checklists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_ApproverId",
                table: "Checklists",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_AreaId",
                table: "Checklists",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_CheckerId",
                table: "Checklists",
                column: "CheckerId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_ClientManagerId",
                table: "Checklists",
                column: "ClientManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_ComponentId",
                table: "Checklists",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_DivisionId",
                table: "Checklists",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_PhaseId",
                table: "Checklists",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_ProjectManagerId",
                table: "Checklists",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_RegionCountryId",
                table: "Checklists",
                column: "RegionCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_ReviewerId",
                table: "Checklists",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_TeamLeaderId",
                table: "Checklists",
                column: "TeamLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_TypologyId",
                table: "Checklists",
                column: "TypologyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistTasks_ChecklistDTOId",
                table: "ChecklistTasks",
                column: "ChecklistDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistTasks_ChecklistTaskDTOId",
                table: "ChecklistTasks",
                column: "ChecklistTaskDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistTasks");

            migrationBuilder.DropTable(
                name: "Checklists");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Typologies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
