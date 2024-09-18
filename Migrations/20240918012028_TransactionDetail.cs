using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCMoneyTransfer.Migrations
{
    /// <inheritdoc />
    public partial class TransactionDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_SenderId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SenderId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SenderId1",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SenderId",
                table: "Transactions",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_SenderId",
                table: "Transactions",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_SenderId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SenderId",
                table: "Transactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "SenderId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "SenderId1",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SenderId1",
                table: "Transactions",
                column: "SenderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_SenderId1",
                table: "Transactions",
                column: "SenderId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
