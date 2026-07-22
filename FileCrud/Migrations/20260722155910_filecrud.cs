using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileCrud.Migrations
{
    /// <inheritdoc />
    public partial class filecrud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StdProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StdName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StdAge = table.Column<int>(type: "int", nullable: false),
                    StdEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StdId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
