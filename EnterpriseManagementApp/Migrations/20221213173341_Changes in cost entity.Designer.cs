﻿// <auto-generated />
using System;
using EnterpriseManagementApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnterpriseManagementApp.Migrations
{
    [DbContext(typeof(EmaDbContext))]
    [Migration("20221213173341_Changes in cost entity")]
    partial class Changesincostentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CostValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Foreman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserSHA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Foremen");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ShortValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MoreInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.ProductionItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ForemanId")
                        .HasColumnType("int");

                    b.Property<int>("HallId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("MagPickupDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuantityPCS")
                        .HasColumnType("int");

                    b.Property<int>("QuantityPallets")
                        .HasColumnType("int");

                    b.Property<bool>("ReadyToPickUp")
                        .HasColumnType("bit");

                    b.Property<bool?>("ReadyToRelease")
                        .HasColumnType("bit");

                    b.Property<bool>("ReceivedByMagazine")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Released")
                        .HasColumnType("bit");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ForemanId");

                    b.HasIndex("HallId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("TypeId");

                    b.ToTable("ProductionItems");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.StockIssueConfirmation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CIDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CIName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CINumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfPayment")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmaCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gross")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("Net")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProductionItemId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("TaxClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductionItemId");

                    b.HasIndex("TaxClassId");

                    b.ToTable("StockIssueConfirmations");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TaxClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxClassValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Diameter")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WallThickness")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.ProductionItem", b =>
                {
                    b.HasOne("EnterpriseManagementApp.Entities.Foreman", "Foreman")
                        .WithMany("ProductionItem")
                        .HasForeignKey("ForemanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnterpriseManagementApp.Entities.Hall", "Hall")
                        .WithMany("ProductionItem")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnterpriseManagementApp.Entities.Material", "Material")
                        .WithMany("ProductionItem")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnterpriseManagementApp.Entities.Type", "Type")
                        .WithMany("ProductionItem")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Foreman");

                    b.Navigation("Hall");

                    b.Navigation("Material");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.StockIssueConfirmation", b =>
                {
                    b.HasOne("EnterpriseManagementApp.Entities.Company", "Company")
                        .WithMany("StockIssueConfirmation")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnterpriseManagementApp.Entities.ProductionItem", "ProductionItem")
                        .WithMany("StockIssueConfirmation")
                        .HasForeignKey("ProductionItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnterpriseManagementApp.Entities.Tax", "Tax")
                        .WithMany("StockIssueConfirmation")
                        .HasForeignKey("TaxClassId");

                    b.Navigation("Company");

                    b.Navigation("ProductionItem");

                    b.Navigation("Tax");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Company", b =>
                {
                    b.Navigation("StockIssueConfirmation");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Foreman", b =>
                {
                    b.Navigation("ProductionItem");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Hall", b =>
                {
                    b.Navigation("ProductionItem");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Material", b =>
                {
                    b.Navigation("ProductionItem");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.ProductionItem", b =>
                {
                    b.Navigation("StockIssueConfirmation");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Tax", b =>
                {
                    b.Navigation("StockIssueConfirmation");
                });

            modelBuilder.Entity("EnterpriseManagementApp.Entities.Type", b =>
                {
                    b.Navigation("ProductionItem");
                });
#pragma warning restore 612, 618
        }
    }
}
