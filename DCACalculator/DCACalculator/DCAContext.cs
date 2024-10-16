using DCACalculator.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCACalculator;

public partial class DCAContext : DbContext
{
    public DCAContext()
    {
    }

    public DCAContext(DbContextOptions<DCAContext> options)
        : base(options)
    {
    }
    public virtual DbSet<AvailableCoin> AvailableCoins { get; set; }
    public virtual DbSet<HistoricalData> HistoricalData { get; set; }
    public virtual DbSet<InvestmentPlan> InvestmentPlans { get; set; }
    public virtual DbSet<Investment> Investments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DCACalculator");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AvailableCoin>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AvailableCoins");

            entity.Property(e => e.Symbol)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<HistoricalData>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.Date, "HistoricalData_date_IDX");

            entity.HasIndex(e => e.Symbol, "HistoricalData_symbol_IDX");

            entity.Property(e => e.Close).HasColumnName("close");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.High).HasColumnName("high");
            entity.Property(e => e.Low).HasColumnName("low");
            entity.Property(e => e.Open).HasColumnName("open");
            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("symbol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
