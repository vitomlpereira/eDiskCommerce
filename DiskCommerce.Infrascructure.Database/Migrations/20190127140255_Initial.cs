using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiskCommerce.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Genre = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerId = table.Column<Guid>(nullable: true),
                    OrderDate = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cashback",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedOrderId = table.Column<Guid>(nullable: true),
                    CashbackValue = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cashback_Order_RelatedOrderId",
                        column: x => x.RelatedOrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiskID = table.Column<Guid>(nullable: false),
                    DiskName = table.Column<string>(nullable: true),
                    DiskGenre = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Unit = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderCashbackItem",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedOrderItemId = table.Column<Guid>(nullable: true),
                    CashbackPercentage = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    CashbackValue = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    OrderCashbackId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCashbackItem", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderCashbackItem_Cashback_OrderCashbackId",
                        column: x => x.OrderCashbackId,
                        principalTable: "Cashback",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderCashbackItem_OrderItem_RelatedOrderItemId",
                        column: x => x.RelatedOrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cashback_RelatedOrderId",
                table: "Cashback",
                column: "RelatedOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BuyerId",
                table: "Order",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCashbackItem_OrderCashbackId",
                table: "OrderCashbackItem",
                column: "OrderCashbackId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCashbackItem_RelatedOrderItemId",
                table: "OrderCashbackItem",
                column: "RelatedOrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disks");

            migrationBuilder.DropTable(
                name: "OrderCashbackItem");

            migrationBuilder.DropTable(
                name: "Cashback");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Buyers");
        }
    }
}
