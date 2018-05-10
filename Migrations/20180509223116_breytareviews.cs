using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace The_Book_Cave.Migrations
{
    public partial class breytareviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
