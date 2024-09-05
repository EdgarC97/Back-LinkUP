using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Link_up.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCoderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Coders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<List<int>>(
                name: "LanguageLevelIds",
                table: "Coders",
                type: "integer[]",
                nullable: false);

            migrationBuilder.AddColumn<List<int>>(
                name: "SoftSkillIds",
                table: "Coders",
                type: "integer[]",
                nullable: false);

            migrationBuilder.AddColumn<List<int>>(
                name: "TechnicalSkillLevelIds",
                table: "Coders",
                type: "integer[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageLevelIds",
                table: "Coders");

            migrationBuilder.DropColumn(
                name: "SoftSkillIds",
                table: "Coders");

            migrationBuilder.DropColumn(
                name: "TechnicalSkillLevelIds",
                table: "Coders");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Birthday",
                table: "Coders",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
