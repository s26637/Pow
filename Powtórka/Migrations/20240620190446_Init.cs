﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Powtórka.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CurrentWei = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "title",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "backpacks",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_backpacks", x => new { x.CharacterId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_backpacks_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_backpacks_item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character_titles",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_titles", x => new { x.CharacterId, x.TitleId });
                    table.ForeignKey(
                        name: "FK_character_titles_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_titles_title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "characters",
                columns: new[] { "Id", "CurrentWei", "FirstName", "LastName", "MaxWeight" },
                values: new object[,]
                {
                    { 1, 0, "Mark", "Kowalski", 100 },
                    { 2, 90, "Tomek", "Adamski", 100 }
                });

            migrationBuilder.InsertData(
                table: "item",
                columns: new[] { "Id", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "Sword", 5 },
                    { 2, "Axe", 6 },
                    { 3, "XXX", 1 },
                    { 4, "BBB", 2 },
                    { 5, "CCC", 10 }
                });

            migrationBuilder.InsertData(
                table: "title",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Title1" },
                    { 2, "Title2" },
                    { 3, "Title3" }
                });

            migrationBuilder.InsertData(
                table: "backpacks",
                columns: new[] { "CharacterId", "ItemId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 10 },
                    { 1, 2, 5 },
                    { 2, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "character_titles",
                columns: new[] { "CharacterId", "TitleId", "AcquiredAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 3, new DateTime(2015, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_backpacks_ItemId",
                table: "backpacks",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_character_titles_TitleId",
                table: "character_titles",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "backpacks");

            migrationBuilder.DropTable(
                name: "character_titles");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "title");
        }
    }
}
