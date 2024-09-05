﻿// <auto-generated />
using System;
using Api_Link_up.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_Link_up.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240905152020_UpdateCoderModel")]
    partial class UpdateCoderModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api_Link_up.Models.Coder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("GenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Coders");
                });

            modelBuilder.Entity("Api_Link_up.Models.CoderLanguageLevel", b =>
                {
                    b.Property<int>("CoderId")
                        .HasColumnType("integer");

                    b.Property<int>("LanguageLevelId")
                        .HasColumnType("integer");

                    b.HasKey("CoderId", "LanguageLevelId");

                    b.HasIndex("LanguageLevelId");

                    b.ToTable("CoderLanguageLevels");
                });

            modelBuilder.Entity("Api_Link_up.Models.CoderSoftSkill", b =>
                {
                    b.Property<int>("CoderId")
                        .HasColumnType("integer");

                    b.Property<int>("SoftSkillId")
                        .HasColumnType("integer");

                    b.HasKey("CoderId", "SoftSkillId");

                    b.HasIndex("SoftSkillId");

                    b.ToTable("CoderSoftSkills");
                });

            modelBuilder.Entity("Api_Link_up.Models.CoderTechnicalSkillLevel", b =>
                {
                    b.Property<int>("CoderId")
                        .HasColumnType("integer");

                    b.Property<int>("TechnicalSkillLevelId")
                        .HasColumnType("integer");

                    b.HasKey("CoderId", "TechnicalSkillLevelId");

                    b.HasIndex("TechnicalSkillLevelId");

                    b.ToTable("CoderTechnicalSkillLevels");
                });

            modelBuilder.Entity("Api_Link_up.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Api_Link_up.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Api_Link_up.Models.LanguageLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LanguageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("LanguageLevels");
                });

            modelBuilder.Entity("Api_Link_up.Models.SoftSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("SoftSkills");
                });

            modelBuilder.Entity("Api_Link_up.Models.TechnicalSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("TechnicalSkills");
                });

            modelBuilder.Entity("Api_Link_up.Models.TechnicalSkillLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("TechnicalSkillId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TechnicalSkillId");

                    b.ToTable("TechnicalSkillLevels");
                });

            modelBuilder.Entity("Api_Link_up.Models.Coder", b =>
                {
                    b.HasOne("Api_Link_up.Models.Gender", "Gender")
                        .WithMany("Coders")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Api_Link_up.Models.CoderLanguageLevel", b =>
                {
                    b.HasOne("Api_Link_up.Models.Coder", "Coder")
                        .WithMany("CoderLanguageLevels")
                        .HasForeignKey("CoderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Link_up.Models.LanguageLevel", "LanguageLevel")
                        .WithMany("CoderLanguageLevels")
                        .HasForeignKey("LanguageLevelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Coder");

                    b.Navigation("LanguageLevel");
                });

            modelBuilder.Entity("Api_Link_up.Models.CoderSoftSkill", b =>
                {
                    b.HasOne("Api_Link_up.Models.Coder", "Coder")
                        .WithMany("CoderSoftSkills")
                        .HasForeignKey("CoderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Link_up.Models.SoftSkill", "SoftSkill")
                        .WithMany("CoderSoftSkills")
                        .HasForeignKey("SoftSkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Coder");

                    b.Navigation("SoftSkill");
                });

            modelBuilder.Entity("Api_Link_up.Models.CoderTechnicalSkillLevel", b =>
                {
                    b.HasOne("Api_Link_up.Models.Coder", "Coder")
                        .WithMany("CoderTechnicalSkillLevels")
                        .HasForeignKey("CoderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Link_up.Models.TechnicalSkillLevel", "TechnicalSkillLevel")
                        .WithMany("CoderTechnicalSkillLevels")
                        .HasForeignKey("TechnicalSkillLevelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Coder");

                    b.Navigation("TechnicalSkillLevel");
                });

            modelBuilder.Entity("Api_Link_up.Models.LanguageLevel", b =>
                {
                    b.HasOne("Api_Link_up.Models.Language", "Language")
                        .WithMany("LanguageLevels")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Api_Link_up.Models.TechnicalSkillLevel", b =>
                {
                    b.HasOne("Api_Link_up.Models.TechnicalSkill", "TechnicalSkill")
                        .WithMany("TechnicalSkillLevels")
                        .HasForeignKey("TechnicalSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TechnicalSkill");
                });

            modelBuilder.Entity("Api_Link_up.Models.Coder", b =>
                {
                    b.Navigation("CoderLanguageLevels");

                    b.Navigation("CoderSoftSkills");

                    b.Navigation("CoderTechnicalSkillLevels");
                });

            modelBuilder.Entity("Api_Link_up.Models.Gender", b =>
                {
                    b.Navigation("Coders");
                });

            modelBuilder.Entity("Api_Link_up.Models.Language", b =>
                {
                    b.Navigation("LanguageLevels");
                });

            modelBuilder.Entity("Api_Link_up.Models.LanguageLevel", b =>
                {
                    b.Navigation("CoderLanguageLevels");
                });

            modelBuilder.Entity("Api_Link_up.Models.SoftSkill", b =>
                {
                    b.Navigation("CoderSoftSkills");
                });

            modelBuilder.Entity("Api_Link_up.Models.TechnicalSkill", b =>
                {
                    b.Navigation("TechnicalSkillLevels");
                });

            modelBuilder.Entity("Api_Link_up.Models.TechnicalSkillLevel", b =>
                {
                    b.Navigation("CoderTechnicalSkillLevels");
                });
#pragma warning restore 612, 618
        }
    }
}
