using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Engtech.BackOffice.Migrations
{
    /// <inheritdoc />
    public partial class BinanceModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppBooks");

            migrationBuilder.DropTable(
                name: "AppAuthors");

            migrationBuilder.CreateTable(
                name: "BinanceOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    OrderListId = table.Column<int>(type: "int", nullable: false),
                    ClientOrderId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    MarketOrderPrice = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    QuantityFilled = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    QuoteQuantityFilled = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    TimeInForce = table.Column<byte>(type: "tinyint", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Side = table.Column<byte>(type: "tinyint", nullable: false),
                    StopPrice = table.Column<decimal>(type: "decimal(18,8)", nullable: true),
                    IcebergQty = table.Column<decimal>(type: "decimal(18,8)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrigQuoteOrderQty = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    SelfTradePreventionMode = table.Column<byte>(type: "tinyint", nullable: false),
                    IsMatched = table.Column<bool>(type: "bit", nullable: false),
                    IsIgnored = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinanceOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BinanceOrdersMatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutedSellQty = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    CumulativeSellQuoteQty = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinanceOrdersMatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BinanceSymbols",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UrlIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SymbolUsdt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinanceSymbols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BinanceOrderMatchBuyOrders",
                columns: table => new
                {
                    OrderMatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinanceOrderMatchBuyOrders", x => new { x.OrderMatchId, x.BuyOrderId });
                    table.ForeignKey(
                        name: "FK_BinanceOrderMatchBuyOrders_BinanceOrdersMatches_OrderMatchId",
                        column: x => x.OrderMatchId,
                        principalTable: "BinanceOrdersMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BinanceOrderMatchBuyOrders_BinanceOrders_BuyOrderId",
                        column: x => x.BuyOrderId,
                        principalTable: "BinanceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BinanceOrderMatchSellOrders",
                columns: table => new
                {
                    OrderMatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinanceOrderMatchSellOrders", x => new { x.OrderMatchId, x.SellOrderId });
                    table.ForeignKey(
                        name: "FK_BinanceOrderMatchSellOrders_BinanceOrdersMatches_OrderMatchId",
                        column: x => x.OrderMatchId,
                        principalTable: "BinanceOrdersMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BinanceOrderMatchSellOrders_BinanceOrders_SellOrderId",
                        column: x => x.SellOrderId,
                        principalTable: "BinanceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinanceOrderMatchBuyOrders_BuyOrderId",
                table: "BinanceOrderMatchBuyOrders",
                column: "BuyOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BinanceOrderMatchSellOrders_SellOrderId",
                table: "BinanceOrderMatchSellOrders",
                column: "SellOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BinanceOrders_OrderId",
                table: "BinanceOrders",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BinanceOrders_Type",
                table: "BinanceOrders",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_BinanceSymbols_Name",
                table: "BinanceSymbols",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinanceOrderMatchBuyOrders");

            migrationBuilder.DropTable(
                name: "BinanceOrderMatchSellOrders");

            migrationBuilder.DropTable(
                name: "BinanceSymbols");

            migrationBuilder.DropTable(
                name: "BinanceOrdersMatches");

            migrationBuilder.DropTable(
                name: "BinanceOrders");

            migrationBuilder.CreateTable(
                name: "AppAuthors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ShortBio = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppBooks_AppAuthors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AppAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBooks_AuthorId",
                table: "AppBooks",
                column: "AuthorId");
        }
    }
}
