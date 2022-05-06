using Microsoft.EntityFrameworkCore.Migrations;

namespace InternetBankaciligi.Data.Migrations
{
    public partial class degisiklikler2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmountTypeWallet_Wallet_WalletsId",
                table: "AmountTypeWallet");

            migrationBuilder.DropForeignKey(
                name: "FK_AmountTypeWallets_Wallet_WalletId",
                table: "AmountTypeWallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Accounts_AccountId",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "Wallets");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_AccountId",
                table: "Wallets",
                newName: "IX_Wallets_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AmountTypeWallet_Wallets_WalletsId",
                table: "AmountTypeWallet",
                column: "WalletsId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AmountTypeWallets_Wallets_WalletId",
                table: "AmountTypeWallets",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Accounts_AccountId",
                table: "Wallets",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmountTypeWallet_Wallets_WalletsId",
                table: "AmountTypeWallet");

            migrationBuilder.DropForeignKey(
                name: "FK_AmountTypeWallets_Wallets_WalletId",
                table: "AmountTypeWallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Accounts_AccountId",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "Wallet");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_AccountId",
                table: "Wallet",
                newName: "IX_Wallet_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AmountTypeWallet_Wallet_WalletsId",
                table: "AmountTypeWallet",
                column: "WalletsId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AmountTypeWallets_Wallet_WalletId",
                table: "AmountTypeWallets",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Accounts_AccountId",
                table: "Wallet",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
