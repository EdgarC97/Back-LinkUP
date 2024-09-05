using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Link_up.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCoderModelWithValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
