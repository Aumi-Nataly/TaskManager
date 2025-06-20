using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "manager",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    surname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manager", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    create_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    manager_id = table.Column<int>(type: "INTEGER", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.id);
                    table.ForeignKey(
                        name: "FK_task_manager_manager_id",
                        column: x => x.manager_id,
                        principalSchema: "dbo",
                        principalTable: "manager",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_task_manager_id",
                schema: "dbo",
                table: "task",
                column: "manager_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "manager",
                schema: "dbo");
        }
    }
}
