using Microsoft.EntityFrameworkCore;
using Models.Transums;

namespace Database.Transums;

public static class TransumEntityConfigurations
{
    public static void ConfigureTransumEntities(this ModelBuilder modelBuilder)
    {
        // TransumBus
        modelBuilder.Entity<TransumBusDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumBus);
            entity.HasKey(e => e.Business);
            entity.ConfigureTransumCommon();
            entity.Property(e => e.Business).HasColumnName(TransumConstants.Business);
        });

        // TransumCat
        modelBuilder.Entity<TransumCatDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumCat);
            entity.HasKey(e => e.Category);
            entity.ConfigureTransumCommon();
            entity.Property(e => e.Category).HasColumnName(TransumConstants.Category);
        });

        // TransumLoc
        modelBuilder.Entity<TransumLocDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumLoc);
            entity.HasKey(e => new { e.City, e.State });
            entity.ConfigureTransumCommon();
            entity.Property(e => e.City).HasColumnName(TransumConstants.City);
            entity.Property(e => e.State).HasColumnName(TransumConstants.State);
        });

        // TransumMo
        modelBuilder.Entity<TransumMoDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumMo);
            entity.HasKey(e => e.Month);
            entity.ConfigureTransumCommon();
            entity.Property(e => e.Month).HasColumnName(TransumConstants.Month);
        });

        // TransumSub
        modelBuilder.Entity<TransumSubDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumSub);
            entity.HasKey(e => e.SubCategory);
            entity.ConfigureTransumCommon();
            entity.Property(e => e.SubCategory).HasColumnName(TransumConstants.SubCategory);
        });

        // TransumYrCat
        modelBuilder.Entity<TransumYrCatDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumYrCat);
            entity.HasKey(e => new { e.Year, e.Category });
            entity.ConfigureTransumCommon();
            entity.Property(e => e.Year).HasColumnName(TransumConstants.Year);
            entity.Property(e => e.Category).HasColumnName(TransumConstants.Category);
        });

        // TransumYr
        modelBuilder.Entity<TransumYrDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumYr);
            entity.HasKey(e => e.Year);
            entity.ConfigureTransumCommon();
            entity.Property(e => e.Year).HasColumnName(TransumConstants.Year);
        });

        // TransumYrMo
        modelBuilder.Entity<TransumYrMoDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumYrMo);
            entity.HasKey(e => new { e.Year, e.Month });
            entity.ConfigureTransumCommon();
            entity.Property(e => e.Year).HasColumnName(TransumConstants.Year);
            entity.Property(e => e.Month).HasColumnName(TransumConstants.Month);
        });

        // TransumYrMoCat
        modelBuilder.Entity<TransumYrMoCatDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumYrMoCat);
            entity.HasKey(e => new { e.Year, e.Month, e.Category });
            entity.ConfigureTransumCommon();
            entity.Property(e => e.Year).HasColumnName(TransumConstants.Year);
            entity.Property(e => e.Month).HasColumnName(TransumConstants.Month);
            entity.Property(e => e.Category).HasColumnName(TransumConstants.Category);
        });

        // TransumYrMoDa
        modelBuilder.Entity<TransumYrMoDaDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumYrMoDa);
            entity.HasKey(e => new { e.Year, e.Month, e.Day });
            entity.ConfigureTransumCommon();
            entity.Property(e => e.Year).HasColumnName(TransumConstants.Year);
            entity.Property(e => e.Month).HasColumnName(TransumConstants.Month);
            entity.Property(e => e.Day).HasColumnName(TransumConstants.Day);
        });

        // TransumYrMoDaCat
        modelBuilder.Entity<TransumYrMoDaCatDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumYrMoDaCat);
            entity.HasKey(e => new { e.Year, e.Month, e.Day, e.Category });
            entity.ConfigureTransumCommon();
            entity.Property(e => e.Year).HasColumnName(TransumConstants.Year);
            entity.Property(e => e.Month).HasColumnName(TransumConstants.Month);
            entity.Property(e => e.Day).HasColumnName(TransumConstants.Day);
            entity.Property(e => e.Category).HasColumnName(TransumConstants.Category);
        });

        // TransumYrMoDaCatSub
        modelBuilder.Entity<TransumYrMoDaCatSubDto>(entity =>
        {
            entity.ToTable(TransumConstants.TransumYrMoDaCatSub);
            entity.HasKey(e => new { e.Year, e.Month, e.Day, e.Category, e.SubCategory });
            entity.ConfigureTransumCommon();
            entity.Property(e => e.Year).HasColumnName(TransumConstants.Year);
            entity.Property(e => e.Month).HasColumnName(TransumConstants.Month);
            entity.Property(e => e.Day).HasColumnName(TransumConstants.Day);
            entity.Property(e => e.Category).HasColumnName(TransumConstants.Category);
            entity.Property(e => e.SubCategory).HasColumnName(TransumConstants.SubCategory);
        });
    }
}
