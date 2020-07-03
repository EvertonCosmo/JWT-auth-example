using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VivoApi.Migrations
{
  public partial class createPasswordHash : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Password",
          table: "Users");

      migrationBuilder.AddColumn<byte[]>(
          name: "PasswordHash",
          table: "Users",
          nullable: true);


    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "PasswordHash",
          table: "Users");

      migrationBuilder.DropColumn(
          name: "PasswordSalt",
          table: "Users");

      migrationBuilder.AddColumn<string>(
          name: "Password",
          table: "Users",
          type: "text",
          nullable: true);
    }
  }
}
