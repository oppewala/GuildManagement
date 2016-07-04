using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace GuildManagement.DataModel.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guild",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    Battlegroup = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Owner = table.Column<Guid>(nullable: true),
                    Realm = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guild", x => x.Key);
                });
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Key);
                });
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    Battlegroup = table.Column<string>(nullable: true),
                    Class = table.Column<int>(nullable: false),
                    ClassID = table.Column<int>(nullable: false),
                    Faction = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    GenderID = table.Column<int>(nullable: false),
                    GuildKey = table.Column<Guid>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Race = table.Column<int>(nullable: false),
                    RaceID = table.Column<int>(nullable: false),
                    Realm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Character_Guild_GuildKey",
                        column: x => x.GuildKey,
                        principalTable: "Guild",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Character");
            migrationBuilder.DropTable("User");
            migrationBuilder.DropTable("Guild");
        }
    }
}
