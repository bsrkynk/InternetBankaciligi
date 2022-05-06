using Microsoft.EntityFrameworkCore.Migrations;

namespace InternetBankaciligi.Data.Migrations
{
    public partial class degisiklikler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AmountTypes_AmountTypeId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "AccountAmountType");

            migrationBuilder.DropTable(
                name: "AccountAmountTypes");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AmountTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountTypeName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AmountTypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountTypeName",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AmountTypeName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalPrice",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionPrice",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmountPrice",
                table: "AmountTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalWealth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmountTypeWallet",
                columns: table => new
                {
                    AmountTypesId = table.Column<int>(type: "int", nullable: false),
                    WalletsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountTypeWallet", x => new { x.AmountTypesId, x.WalletsId });
                    table.ForeignKey(
                        name: "FK_AmountTypeWallet_AmountTypes_AmountTypesId",
                        column: x => x.AmountTypesId,
                        principalTable: "AmountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmountTypeWallet_Wallet_WalletsId",
                        column: x => x.WalletsId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmountTypeWallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountTypeId = table.Column<int>(type: "int", nullable: false),
                    AvarageBuyPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountOfAmountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalWelthOfAmountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountTypeWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmountTypeWallets_AmountTypes_AmountTypeId",
                        column: x => x.AmountTypeId,
                        principalTable: "AmountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmountTypeWallets_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmountTypeWallet_WalletsId",
                table: "AmountTypeWallet",
                column: "WalletsId");

            migrationBuilder.CreateIndex(
                name: "IX_AmountTypeWallets_AmountTypeId",
                table: "AmountTypeWallets",
                column: "AmountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AmountTypeWallets_WalletId",
                table: "AmountTypeWallets",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_AccountId",
                table: "Wallet",
                column: "AccountId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmountTypeWallet");

            migrationBuilder.DropTable(
                name: "AmountTypeWallets");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropColumn(
                name: "AmountTypeName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionPrice",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AmountPrice",
                table: "AmountTypes");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AmountTypeId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AccountTypeName",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AccountAmountType",
                columns: table => new
                {
                    AccountsId = table.Column<int>(type: "int", nullable: false),
                    AmountTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAmountType", x => new { x.AccountsId, x.AmountTypesId });
                    table.ForeignKey(
                        name: "FK_AccountAmountType_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountAmountType_AmountTypes_AmountTypesId",
                        column: x => x.AmountTypesId,
                        principalTable: "AmountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountAmountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAmountTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountAmountTypes_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountAmountTypes_AmountTypes_AmountTypeId",
                        column: x => x.AmountTypeId,
                        principalTable: "AmountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AmountTypeId",
                table: "Transactions",
                column: "AmountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeName",
                table: "Accounts",
                column: "AccountTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountAmountType_AmountTypesId",
                table: "AccountAmountType",
                column: "AmountTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAmountTypes_AccountId",
                table: "AccountAmountTypes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAmountTypes_AmountTypeId",
                table: "AccountAmountTypes",
                column: "AmountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AmountTypes_AmountTypeId",
                table: "Transactions",
                column: "AmountTypeId",
                principalTable: "AmountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
