using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteProject.DAL.Migrations
{
    public partial class InitNoteDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsActive" },
                values: new object[] { new DateTime(2023, 11, 23, 16, 10, 19, 897, DateTimeKind.Local).AddTicks(100), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 23, 15, 49, 20, 241, DateTimeKind.Local).AddTicks(2322));
        }
    }
}
