using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Config;

public class TransactionConfig : IEntityTypeConfiguration<TransactionDto>
{
    public void Configure(EntityTypeBuilder<TransactionDto> entity)
    {
        entity.ToTable(TableConstants.Transactions);

        // Define shadow primary key
        entity.Property<string>(ColumnConstants.CommonId)
            .HasColumnName(ColumnConstants.Id);

        entity.HasKey(ColumnConstants.CommonId);

        // Map CommonDto
        entity.OwnsOne(e => e.Common, common =>
        {
            common.Property(c => c.Id).HasColumnName(ColumnConstants.Id);
            common.Property(c => c.Number).HasColumnName(ColumnConstants.Number);
            common.Property(c => c.Comments).HasColumnName(ColumnConstants.Comments);
        });

        // Map ExactDateFields
        entity.OwnsOne(e => e.Date, date =>
        {
            date.Property(d => d.Year).HasColumnName(ColumnConstants.Year);
            date.Property(d => d.Month).HasColumnName(ColumnConstants.Month);
            date.Property(d => d.Day).HasColumnName(ColumnConstants.Day);
            date.Property(d => d.Weekday).HasColumnName(ColumnConstants.Weekday);
            date.Property(d => d.Date).HasColumnName(ColumnConstants.Date);
        });

        // Map transaction-specific fields
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
