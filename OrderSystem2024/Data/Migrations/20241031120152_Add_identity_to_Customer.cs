using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem2024.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_identity_to_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerUserId",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerUserId",
                table: "Customer",
                column: "CustomerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_CustomerUserId",
                table: "Customer",
                column: "CustomerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_CustomerUserId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerUserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "Customer");
        }
    }
}
