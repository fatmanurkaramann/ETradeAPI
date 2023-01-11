using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETradeAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class miguseraddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullAddress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullAddress",
                table: "Users");
        }
    }
}
