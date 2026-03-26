using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TetPee.Repository.Migrations
{
    /// <inheritdoc />
    public partial class hhu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Password", "Role", "UpdatedAt" },
                values: new object[] { new Guid("58ad06c5-d1b6-454e-8ae4-d8a9819fb443"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin@gmail.com", false, "PiedTeam", "Admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("58ad06c5-d1b6-454e-8ae4-d8a9819fb443"));
        }
    }
}
