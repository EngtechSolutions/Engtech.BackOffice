using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Engtech.BackOffice.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSymbolUrlIcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlIcon",
                table: "BinanceSymbols");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlIcon",
                table: "BinanceSymbols",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
