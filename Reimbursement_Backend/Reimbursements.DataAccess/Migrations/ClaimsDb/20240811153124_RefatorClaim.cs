using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reimbursements.DataAccess.Migrations.ClaimsDb
{
    /// <inheritdoc />
    public partial class RefatorClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Claims");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Claims",
                newName: "RequestedValue");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Claims",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ApprovedValue",
                table: "Claims",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Proccessed",
                table: "Claims",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "ApprovedValue",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "Proccessed",
                table: "Claims");

            migrationBuilder.RenameColumn(
                name: "RequestedValue",
                table: "Claims",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
