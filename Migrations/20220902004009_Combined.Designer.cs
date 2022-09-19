﻿// <auto-generated />
using System;
using Account.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Account.Migrations
{
    [DbContext(typeof(AccountContext))]
    [Migration("20220902004009_Combined")]
    partial class Combined
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Account.Models.COA", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AccCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Acclevel")
                        .HasColumnType("int");

                    b.Property<string>("Accname")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccCode")
                        .IsUnique();

                    b.ToTable("COA");
                });

            modelBuilder.Entity("Account.Models.Voucher", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<decimal>("cramt")
                        .HasColumnType("decimal (18,3)");

                    b.Property<string>("crcoacode")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("crcoaname")
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("dramt")
                        .HasColumnType("decimal(18,3)");

                    b.Property<string>("drcoacode")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("drcoaname")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("verified")
                        .HasColumnType("int");

                    b.Property<DateTime>("voucherdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("voucherno")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("Voucher");
                });
#pragma warning restore 612, 618
        }
    }
}
