using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reimbursements.DataAccess.Migrations.ClaimsDb
{
    /// <inheritdoc />
    public partial class ClaimApprovals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApproveNote",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveNote",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Claims");
        }
    }
}
