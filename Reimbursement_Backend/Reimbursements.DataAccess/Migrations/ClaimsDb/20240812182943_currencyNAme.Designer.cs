﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reimbursements.DataAccess.Context;

#nullable disable

namespace Reimbursements.DataAccess.Migrations.ClaimsDb
{
    [DbContext(typeof(ClaimsDbContext))]
    [Migration("20240812182943_currencyNAme")]
    partial class currencyNAme
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Reimbursements.DataAccess.Context.Entities.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("banks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BankName = "Absa"
                        },
                        new
                        {
                            Id = 2,
                            BankName = "FNB"
                        },
                        new
                        {
                            Id = 3,
                            BankName = "Nedbank"
                        },
                        new
                        {
                            Id = 4,
                            BankName = "African"
                        });
                });

            modelBuilder.Entity("Reimbursements.DataAccess.Context.Entities.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<decimal>("ApprovedValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Proccessed")
                        .HasColumnType("bit");

                    b.Property<decimal>("RequestedValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("typeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("TypeId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("Reimbursements.DataAccess.Context.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyCode = "INR"
                        },
                        new
                        {
                            Id = 2,
                            CurrencyCode = "ZAR"
                        },
                        new
                        {
                            Id = 3,
                            CurrencyCode = "USD"
                        },
                        new
                        {
                            Id = 4,
                            CurrencyCode = "EUR"
                        });
                });

            modelBuilder.Entity("Reimbursements.DataAccess.Context.Entities.ReimbursementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReimbursementTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Medical"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Travel"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Misc"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Entertainment"
                        });
                });

            modelBuilder.Entity("Reimbursements.DataAccess.Context.Entities.ReimbursementsUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<string>("Bank_Account_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsApprover")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pan_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("ReimbursementsUser");
                });

            modelBuilder.Entity("Reimbursements.DataAccess.Context.Entities.Claim", b =>
                {
                    b.HasOne("Reimbursements.DataAccess.Context.Entities.Currency", "Currency")
                        .WithMany("Claims")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reimbursements.DataAccess.Context.Entities.ReimbursementType", "Type")
                        .WithMany("Claims")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Reimbursements.DataAccess.Context.Entities.ReimbursementsUser", b =>
                {
                    b.HasOne("Reimbursements.DataAccess.Context.Entities.Bank", "Bank")
                        .WithMany("Users")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Reimbursements.DataAccess.Context.Entities.Bank", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Reimbursements.DataAccess.Context.Entities.Currency", b =>
                {
                    b.Navigation("Claims");
                });

            modelBuilder.Entity("Reimbursements.DataAccess.Context.Entities.ReimbursementType", b =>
                {
                    b.Navigation("Claims");
                });
#pragma warning restore 612, 618
        }
    }
}
