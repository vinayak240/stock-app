﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockExchangeService.DataContext;

namespace StockExchangeService.Migrations
{
    [DbContext(typeof(StockExchangeDbContext))]
    [Migration("20201212151842_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StockExchangeService.Entities.Company", b =>
                {
                    b.Property<string>("CompanyCode")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("StockExchanges")
                        .HasColumnType("text");

                    b.HasKey("CompanyCode");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StockExchangeService.Entities.StockExchange", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("StockExchanges");
                });
#pragma warning restore 612, 618
        }
    }
}
