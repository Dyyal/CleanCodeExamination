﻿// <auto-generated />
using CleanCodeExamination.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanCodeExamination.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211202151135_v4")]
    partial class v4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("CleanCodeExamination.Data.Entities.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ScoreId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ScoreId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CleanCodeExamination.Data.Entities.Score", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<double>("Average")
                        .HasColumnType("REAL");

                    b.Property<int>("Guesses")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Highscore")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Player")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoundsPlayed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("CleanCodeExamination.Data.Entities.Player", b =>
                {
                    b.HasOne("CleanCodeExamination.Data.Entities.Score", "Score")
                        .WithMany()
                        .HasForeignKey("ScoreId");

                    b.Navigation("Score");
                });
#pragma warning restore 612, 618
        }
    }
}
