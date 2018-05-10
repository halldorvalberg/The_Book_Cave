using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace The_Book_Cave.Migrations
{
    public partial class UsertableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddressCity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BillingAddressCountry",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BillingAddressHouseNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BillingAddressLine2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BillingAddressStreet",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BillingAddressZipCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressCity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressCountry",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressHouseNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressLine2",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "Users",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FavoriteBook",
                table: "Users",
                newName: "HouseNumber");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddressZipCode",
                table: "Users",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddressStreet",
                table: "Users",
                newName: "City");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Users",
                newName: "ProfilePicture");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "HouseNumber",
                table: "Users",
                newName: "FavoriteBook");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Users",
                newName: "DeliveryAddressZipCode");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Users",
                newName: "DeliveryAddressStreet");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressCity",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressCountry",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressHouseNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressLine2",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressStreet",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressZipCode",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddressCity",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddressCountry",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddressHouseNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddressLine2",
                table: "Users",
                nullable: true);
        }
    }
}
