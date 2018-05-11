using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace The_Book_Cave.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ISBN = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Pages = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    PublicationYear = table.Column<DateTime>(nullable: false),
                    Publisher = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
