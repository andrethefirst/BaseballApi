﻿// <auto-generated />
using BaseballPlayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseballPlayer.Migrations
{
    [DbContext(typeof(BaseballPlayerContext))]
    [Migration("20211107224634_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BaseballPlayer.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("JerseyNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Position")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Team")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            JerseyNumber = 27,
                            Name = "Mike Trout",
                            Position = "CF",
                            Team = "Angels"
                        },
                        new
                        {
                            PlayerId = 2,
                            JerseyNumber = 5,
                            Name = "Freddie Freeman",
                            Position = "1B",
                            Team = "Braves"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}