using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Invoice.DataAccess.Migrations
{
    public partial class invoicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_InvoiceDetails_InvoiceDetailsId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_InvoiceDetailsId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InvoiceDetailsId",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceDetailsId = table.Column<int>(nullable: true),
                    InvoiceId = table.Column<int>(nullable: false),
                    ProuductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_InvoiceDetails_InvoiceDetailsId",
                        column: x => x.InvoiceDetailsId,
                        principalTable: "InvoiceDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_InvoiceDetailsId",
                table: "OrderDetails",
                column: "InvoiceDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceDetailsId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_InvoiceDetailsId",
                table: "Product",
                column: "InvoiceDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_InvoiceDetails_InvoiceDetailsId",
                table: "Product",
                column: "InvoiceDetailsId",
                principalTable: "InvoiceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
