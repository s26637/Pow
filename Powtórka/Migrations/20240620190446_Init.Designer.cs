﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Powtórka.Data;

#nullable disable

namespace Powtórka.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240620190446_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Powtórka.Models.Backpack", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("backpacks");

                    b.HasData(
                        new
                        {
                            CharacterId = 2,
                            ItemId = 1,
                            Amount = 5
                        },
                        new
                        {
                            CharacterId = 1,
                            ItemId = 1,
                            Amount = 10
                        },
                        new
                        {
                            CharacterId = 1,
                            ItemId = 2,
                            Amount = 5
                        });
                });

            modelBuilder.Entity("Powtórka.Models.CharacterTitle", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CharacterId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("character_titles");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            TitleId = 1,
                            AcquiredAt = new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CharacterId = 1,
                            TitleId = 2,
                            AcquiredAt = new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CharacterId = 1,
                            TitleId = 3,
                            AcquiredAt = new DateTime(2015, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Powtórka.Models.Chatacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentWei")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentWei = 0,
                            FirstName = "Mark",
                            LastName = "Kowalski",
                            MaxWeight = 100
                        },
                        new
                        {
                            Id = 2,
                            CurrentWei = 90,
                            FirstName = "Tomek",
                            LastName = "Adamski",
                            MaxWeight = 100
                        });
                });

            modelBuilder.Entity("Powtórka.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("item");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sword",
                            Weight = 5
                        },
                        new
                        {
                            Id = 2,
                            Name = "Axe",
                            Weight = 6
                        },
                        new
                        {
                            Id = 3,
                            Name = "XXX",
                            Weight = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "BBB",
                            Weight = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "CCC",
                            Weight = 10
                        });
                });

            modelBuilder.Entity("Powtórka.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("title");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Title1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Title2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Title3"
                        });
                });

            modelBuilder.Entity("Powtórka.Models.Backpack", b =>
                {
                    b.HasOne("Powtórka.Models.Chatacter", "Chatacter")
                        .WithMany("Backpacks")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Powtórka.Models.Item", "Item")
                        .WithMany("Backpacks")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chatacter");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Powtórka.Models.CharacterTitle", b =>
                {
                    b.HasOne("Powtórka.Models.Chatacter", "Chatacter")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Powtórka.Models.Title", "Title")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chatacter");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Powtórka.Models.Chatacter", b =>
                {
                    b.Navigation("Backpacks");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("Powtórka.Models.Item", b =>
                {
                    b.Navigation("Backpacks");
                });

            modelBuilder.Entity("Powtórka.Models.Title", b =>
                {
                    b.Navigation("CharacterTitles");
                });
#pragma warning restore 612, 618
        }
    }
}
