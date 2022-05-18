﻿// <auto-generated />
using InternetBankaciligi.Data.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InternetBankaciligi.Data.Migrations
{
    [DbContext(typeof(InternetBankaciligiContext))]
    [Migration("20220518201534_ibaneklendi4")]
    partial class ibaneklendi4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AmountTypeWallet", b =>
                {
                    b.Property<int>("AmountTypesId")
                        .HasColumnType("int");

                    b.Property<int>("WalletsId")
                        .HasColumnType("int");

                    b.HasKey("AmountTypesId", "WalletsId");

                    b.HasIndex("WalletsId");

                    b.ToTable("AmountTypeWallet");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.AmountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmountName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AmountPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AmountName")
                        .IsUnique();

                    b.ToTable("AmountTypes");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.AmountTypeWallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmountOfAmountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AmountTypeId")
                        .HasColumnType("int");

                    b.Property<string>("AvarageBuyPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TotalWelthOfAmountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AmountTypeId");

                    b.HasIndex("WalletId");

                    b.ToTable("AmountTypeWallets");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmountTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TotalPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("TransactionTypeName");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TCNo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerNo")
                        .IsUnique()
                        .HasFilter("[CustomerNo] IS NOT NULL");

                    b.HasIndex("TCNo")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TotalWealth")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("AmountTypeWallet", b =>
                {
                    b.HasOne("InternetBankaciligi.Entities.Concrete.AmountType", null)
                        .WithMany()
                        .HasForeignKey("AmountTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternetBankaciligi.Entities.Concrete.Wallet", null)
                        .WithMany()
                        .HasForeignKey("WalletsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.Account", b =>
                {
                    b.HasOne("InternetBankaciligi.Entities.Concrete.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.AmountTypeWallet", b =>
                {
                    b.HasOne("InternetBankaciligi.Entities.Concrete.AmountType", "AmountType")
                        .WithMany()
                        .HasForeignKey("AmountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternetBankaciligi.Entities.Concrete.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AmountType");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.Transaction", b =>
                {
                    b.HasOne("InternetBankaciligi.Entities.Concrete.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.Wallet", b =>
                {
                    b.HasOne("InternetBankaciligi.Entities.Concrete.Account", "Account")
                        .WithOne("Wallet")
                        .HasForeignKey("InternetBankaciligi.Entities.Concrete.Wallet", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.Account", b =>
                {
                    b.Navigation("Transactions");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("InternetBankaciligi.Entities.Concrete.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
