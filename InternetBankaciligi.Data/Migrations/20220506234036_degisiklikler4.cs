using Microsoft.EntityFrameworkCore.Migrations;

namespace InternetBankaciligi.Data.Migrations
{
    public partial class degisiklikler4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionTypeName",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeName",
                table: "Transactions",
                column: "TransactionTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionTypeName",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeName",
                table: "Transactions",
                column: "TransactionTypeName",
                unique: true);
        }
    }
}
