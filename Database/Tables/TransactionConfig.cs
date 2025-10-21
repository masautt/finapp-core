using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class TransactionConfig : IEntityTypeConfiguration<TransactionDto>
{
    public void Configure(EntityTypeBuilder<TransactionDto> entity)
    {
        entity.ToTable(TableConstants.Transactions);

        // CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // ExactDateFields
        entity.ConfigureExactDate(e => e.Date);

        // Transaction-specific fields
        entity.Property(e => e.Category).HasColumnName(ColumnConstants.Category);
        entity.Property(e => e.SubCategory).HasColumnName(ColumnConstants.SubCategory);
        entity.Property(e => e.Amount).HasColumnName(ColumnConstants.Amount);
        entity.Property(e => e.Business).HasColumnName(ColumnConstants.Business);
        entity.Property(e => e.City).HasColumnName(ColumnConstants.City);
        entity.Property(e => e.State).HasColumnName(ColumnConstants.State);
        entity.Property(e => e.Description).HasColumnName(ColumnConstants.Description);
        entity.Property(e => e.Comments).HasColumnName(ColumnConstants.Comments);
        entity.Property(e => e.Recipient).HasColumnName(ColumnConstants.Recipient);
        entity.Property(e => e.Necessity).HasColumnName(ColumnConstants.Necessity);
        entity.Property(e => e.Reimburse).HasColumnName(ColumnConstants.Reimburse);
        entity.Property(e => e.Recurring).HasColumnName(ColumnConstants.Recurring);
        entity.Property(e => e.Ex).HasColumnName(ColumnConstants.Ex);
    }
}