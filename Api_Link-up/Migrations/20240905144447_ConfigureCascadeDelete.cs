using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Link_up.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoderLanguageLevels_LanguageLevels_LanguageLevelId",
                table: "CoderLanguageLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_CoderSoftSkills_SoftSkills_SoftSkillId",
                table: "CoderSoftSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CoderTechnicalSkillLevels_TechnicalSkillLevels_TechnicalSki~",
                table: "CoderTechnicalSkillLevels");

            migrationBuilder.AddForeignKey(
                name: "FK_CoderLanguageLevels_LanguageLevels_LanguageLevelId",
                table: "CoderLanguageLevels",
                column: "LanguageLevelId",
                principalTable: "LanguageLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CoderSoftSkills_SoftSkills_SoftSkillId",
                table: "CoderSoftSkills",
                column: "SoftSkillId",
                principalTable: "SoftSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CoderTechnicalSkillLevels_TechnicalSkillLevels_TechnicalSki~",
                table: "CoderTechnicalSkillLevels",
                column: "TechnicalSkillLevelId",
                principalTable: "TechnicalSkillLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoderLanguageLevels_LanguageLevels_LanguageLevelId",
                table: "CoderLanguageLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_CoderSoftSkills_SoftSkills_SoftSkillId",
                table: "CoderSoftSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CoderTechnicalSkillLevels_TechnicalSkillLevels_TechnicalSki~",
                table: "CoderTechnicalSkillLevels");

            migrationBuilder.AddForeignKey(
                name: "FK_CoderLanguageLevels_LanguageLevels_LanguageLevelId",
                table: "CoderLanguageLevels",
                column: "LanguageLevelId",
                principalTable: "LanguageLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoderSoftSkills_SoftSkills_SoftSkillId",
                table: "CoderSoftSkills",
                column: "SoftSkillId",
                principalTable: "SoftSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoderTechnicalSkillLevels_TechnicalSkillLevels_TechnicalSki~",
                table: "CoderTechnicalSkillLevels",
                column: "TechnicalSkillLevelId",
                principalTable: "TechnicalSkillLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
