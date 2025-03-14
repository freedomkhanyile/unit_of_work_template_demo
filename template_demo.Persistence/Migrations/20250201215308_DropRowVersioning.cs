using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace template_demo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DropRowVersioning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Assets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RowVersion",
                table: "Users",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RowVersion",
                table: "Assets",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
