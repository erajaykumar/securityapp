using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kibana.Rule.Engine.Migrations
{
    /// <inheritdoc />
    public partial class addingnewcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfKeyword",
                table: "Rules_Table",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DurationNotaion",
                table: "Rules_Table",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FromDuration",
                table: "Rules_Table",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfKeyword",
                table: "Rules_Table");

            migrationBuilder.DropColumn(
                name: "DurationNotaion",
                table: "Rules_Table");

            migrationBuilder.DropColumn(
                name: "FromDuration",
                table: "Rules_Table");
        }
    }
}
