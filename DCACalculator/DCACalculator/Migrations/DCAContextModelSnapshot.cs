﻿// <auto-generated />
using System;
using DCACalculator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DCACalculator.Migrations
{
    [DbContext(typeof(DCAContext))]
    partial class DCAContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DCACalculator.Entities.AvailableCoin", b =>
                {
                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8000)")
                        .HasColumnName("symbol");

                    b.ToTable((string)null);

                    b.ToView("AvailableCoins", (string)null);
                });

            modelBuilder.Entity("DCACalculator.Entities.HistoricalData", b =>
                {
                    b.Property<float>("Close")
                        .HasColumnType("real")
                        .HasColumnName("close");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<float>("High")
                        .HasColumnType("real")
                        .HasColumnName("high");

                    b.Property<float>("Low")
                        .HasColumnType("real")
                        .HasColumnName("low");

                    b.Property<float>("Open")
                        .HasColumnType("real")
                        .HasColumnName("open");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("symbol");

                    b.HasIndex(new[] { "Date" }, "HistoricalData_date_IDX");

                    b.HasIndex(new[] { "Symbol" }, "HistoricalData_symbol_IDX");

                    b.ToTable("HistoricalData");
                });

            modelBuilder.Entity("DCACalculator.Entities.InvestmentPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("InvestmentPlans");
                });

            modelBuilder.Entity("DCACalculator.Entities.InvestmentPlanProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AmountInvestedEur")
                        .HasColumnType("float");

                    b.Property<double>("AmountOwned")
                        .HasColumnType("float");

                    b.Property<int>("InvestmentPlanId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvestmentPlanId");

                    b.ToTable("InvestmentPlanProgress");
                });

            modelBuilder.Entity("DCACalculator.Entities.InvestmentPlanProgress", b =>
                {
                    b.HasOne("DCACalculator.Entities.InvestmentPlan", "InvestmentPlan")
                        .WithMany("InvestmentProgress")
                        .HasForeignKey("InvestmentPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvestmentPlan");
                });

            modelBuilder.Entity("DCACalculator.Entities.InvestmentPlan", b =>
                {
                    b.Navigation("InvestmentProgress");
                });
#pragma warning restore 612, 618
        }
    }
}
