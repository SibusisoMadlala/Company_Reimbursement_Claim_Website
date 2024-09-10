using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reimbursements.DataAccess.Migrations.ClaimsDb
{
    /// <inheritdoc />
    public partial class addingMasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReimbursementTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReimbursementTypes", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "ReimbursementTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Medical" },
                    { 2, "Travel" },
                    { 3, "Food" },
                    { 4, "Misc" },
                    { 5, "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "banks",
                columns: new[] { "ID", "BankName" },
                values: new object[,]
                {
                    { 1, "Absa" },
                    { 2, "FNB" },
                    { 3, "Nedbank" },
                    { 4, "African" }
                });

            migrationBuilder.InsertData(
                table: "currencies",
                columns: new[] { "ID", "CurrencyCode" },
                values: new object[,]
                {
                    { 1, "INR" },
                    { 2, "ZAR" },
                    { 3, "USD" },
                    { 4, "EUR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banks");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropTable(
                name: "ReimbursementTypes");
        }
    }
}
