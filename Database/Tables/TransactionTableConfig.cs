using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class TransactionTableConfig : IEntityTypeConfiguration<TransactionTableDto>
{
    public void Configure(EntityTypeBuilder<TransactionTableDto> entity)
    {
        entity.ToTable(TableConstants.Transactions);

        // CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // ExactDateFields
        entity.ConfigureExactDate(e => e.Date);

        // Transaction-specific fields
        entity.Property(e => e.Category).HasColumnName(TableColumnConstants.Category);
        entity.Property(e => e.SubCategory).HasColumnName(TableColumnConstants.SubCategory);
        entity.Property(e => e.Amount).HasColumnName(TableColumnConstants.Amount);
        entity.Property(e => e.Business).HasColumnName(TableColumnConstants.Business);
        entity.Property(e => e.City).HasColumnName(TableColumnConstants.City);
        entity.Property(e => e.State).HasColumnName(TableColumnConstants.State);
        entity.Property(e => e.Description).HasColumnName(TableColumnConstants.Description);
        entity.Property(e => e.Comments).HasColumnName(TableColumnConstants.Comments);
        entity.Property(e => e.Recipient).HasColumnName(TableColumnConstants.Recipient);
        entity.Property(e => e.Necessity).HasColumnName(TableColumnConstants.Necessity);
        entity.Property(e => e.Reimburse).HasColumnName(TableColumnConstants.Reimburse);
        entity.Property(e => e.Recurring).HasColumnName(TableColumnConstants.Recurring);
        entity.Property(e => e.Ex).HasColumnName(TableColumnConstants.Ex);
    }
}