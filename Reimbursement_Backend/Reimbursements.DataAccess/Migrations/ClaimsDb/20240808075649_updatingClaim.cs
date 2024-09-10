using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reimbursements.DataAccess.Migrations.ClaimsDb
{
    /// <inheritdoc />
    public partial class updatingClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

           

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReimbursementsUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pan_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    Bank_Account_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApprover = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReimbursementsUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReimbursementsUser_banks_BankId",
                        column: x => x.BankId,
                        principalTable: "banks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_CurrencyId",
                table: "Claims",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_TypeId",
                table: "Claims",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReimbursementsUser_BankId",
                table: "ReimbursementsUser",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_ReimbursementTypes_TypeId",
                table: "Claims",
                column: "TypeId",
                principalTable: "ReimbursementTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_currencies_CurrencyId",
                table: "Claims",
                column: "CurrencyId",
                principalTable: "currencies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_ReimbursementTypes_TypeId",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_Claims_currencies_CurrencyId",
                table: "Claims");

            migrationBuilder.DropTable(
                name: "ReimbursementsUser");

            migrationBuilder.DropIndex(
                name: "IX_Claims_CurrencyId",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Claims_TypeId",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Claims");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
