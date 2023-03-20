using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewApps.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyholding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_Policy_PolicyId",
                table: "Holdings");

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "Holdings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DistributorClientAcctNum",
                table: "Holdings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_Policy_PolicyId",
                table: "Holdings",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holdings_Policy_PolicyId",
                table: "Holdings");

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "Holdings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DistributorClientAcctNum",
                table: "Holdings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Holdings_Policy_PolicyId",
                table: "Holdings",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
