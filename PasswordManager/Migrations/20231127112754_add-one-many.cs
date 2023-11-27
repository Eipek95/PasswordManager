using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManager.Migrations
{
    /// <inheritdoc />
    public partial class addonemany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MyPasswords_CategoryId",
                table: "MyPasswords");

            migrationBuilder.CreateIndex(
                name: "IX_MyPasswords_CategoryId",
                table: "MyPasswords",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MyPasswords_CategoryId",
                table: "MyPasswords");

            migrationBuilder.CreateIndex(
                name: "IX_MyPasswords_CategoryId",
                table: "MyPasswords",
                column: "CategoryId",
                unique: true);
        }
    }
}
