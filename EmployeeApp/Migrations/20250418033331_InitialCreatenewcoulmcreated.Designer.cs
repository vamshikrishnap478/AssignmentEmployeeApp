﻿// <auto-generated />
using System;
using EmployeeApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250418033331_InitialCreatenewcoulmcreated")]
    partial class InitialCreatenewcoulmcreated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EmployeeApp.Data.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Createdate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateOfJoin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Designation")
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EmployeeApp.Data.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("State");
                });
#pragma warning restore 612, 618
        }
    }
}
