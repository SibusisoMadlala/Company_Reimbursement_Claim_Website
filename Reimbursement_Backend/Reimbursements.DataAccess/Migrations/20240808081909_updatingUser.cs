using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reimbursements.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatingUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bank",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsApprover",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BankId",
                table: "AspNetUsers",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bank_BankId",
                table: "AspNetUsers",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Bank_BankId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BankId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsApprover",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "UserName",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
