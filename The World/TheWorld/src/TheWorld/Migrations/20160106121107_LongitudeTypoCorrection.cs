using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TheWorld.Migrations
{
    public partial class LongitudeTypoCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Logitude", table: "Stop");
            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Stop",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Longitude", table: "Stop");
            migrationBuilder.AddColumn<double>(
                name: "Logitude",
                table: "Stop",
                nullable: false,
                defaultValue: 0);
        }
    }
}
