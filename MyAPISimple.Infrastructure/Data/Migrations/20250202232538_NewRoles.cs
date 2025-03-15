using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPISimple.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71298746-9408-46a9-a356-89cfca5c86b6", "3c28a6d5-37e7-402a-9551-7a1b2fe5b857", "Coach", "COACH" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "71298746-9408-46a9-a356-89cfca5c86b6");
        }
    }
}
