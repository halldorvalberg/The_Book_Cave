using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace The_Book_Cave.Migrations
{
    public partial class ShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    CartId = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Carts_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    BillingAddressCity = table.Column<string>(nullable: true),
                    BillingAddressCountry = table.Column<string>(nullable: true),
                    BillingAddressHouseNumber = table.Column<string>(nullable: true),
                    BillingAddressLine2 = table.Column<string>(nullable: true),
                    BillingAddressStreet = table.Column<string>(nullable: true),
                    BillingAddressZipCode = table.Column<string>(nullable: true),
                    DeliveryAddressCity = table.Column<string>(nullable: true),
                    DeliveryAddressCountry = table.Column<string>(nullable: true),
                    DeliveryAddressHouseNumber = table.Column<string>(nullable: true),
                    DeliveryAddressLine2 = table.Column<string>(nullable: true),
                    DeliveryAddressStreet = table.Column<string>(nullable: true),
                    DeliveryAddressZipCode = table.Column<string>(nullable: true),
                    FavoriteBook = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_BookId",
                table: "Carts",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
