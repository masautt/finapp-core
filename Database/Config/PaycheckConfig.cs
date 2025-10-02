using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Config;

public class PaycheckConfig : IEntityTypeConfiguration<PaycheckDto>
{
    public void Configure(EntityTypeBuilder<PaycheckDto> entity)
    {
        entity.ToTable(TableConstants.Paychecks);

        // Define a shadow property as the primary key
        entity.Property<string>(ColumnConstants.CommonId)
            .HasColumnName(ColumnConstants.Id);

        entity.HasKey(ColumnConstants.CommonId); // shadow PK

        // Map CommonDto
        entity.OwnsOne(e => e.Common, common =>
        {
            common.Property(c => c.Id).HasColumnName(ColumnConstants.Id);
            common.Property(c => c.Number).HasColumnName(ColumnConstants.Number);
            common.Property(c => c.Comments).HasColumnName(ColumnConstants.Comments);
        });

        // Map DateRangeFields
        entity.OwnsOne(e => e.DateRange, date =>
        {
            date.Property(d => d.StartDate).HasColumnName(ColumnConstants.StartDate);
            date.Property(d => d.EndDate).HasColumnName(ColumnConstants.EndDate);
            date.Property(d => d.Month).HasColumnName(ColumnConstants.Month);
            date.Property(d => d.Year).HasColumnName(ColumnConstants.Year);
        });

        // Map Paycheck-specific scalars
        entity.Property(e => e.Source).HasColumnName(ColumnConstants.Source);
        entity.Property(e => e.CheckDate).HasColumnName(ColumnConstants.CheckDate);
        entity.Property(e => e.HoursPaid).HasColumnName(ColumnConstants.HoursPaid);
        entity.Property(e => e.PayRate).HasColumnName(ColumnConstants.PayRate);
        entity.Property(e => e.OvertimeHours).HasColumnName(ColumnConstants.OvertimeHours);
        entity.Property(e => e.HolidayUsed).HasColumnName(ColumnConstants.HolidayUsed);
        entity.Property(e => e.FixedFloatingHoliday).HasColumnName(ColumnConstants.FixedFloatingHoliday);
        entity.Property(e => e.GrossEarnings).HasColumnName(ColumnConstants.GrossEarnings);
        entity.Property(e => e.TaxableGross).HasColumnName(ColumnConstants.TaxableGross);
        entity.Property(e => e.TotalTaxes).HasColumnName(ColumnConstants.TotalTaxes);
        entity.Property(e => e.TotalDeductions).HasColumnName(ColumnConstants.TotalDeductions);
        entity.Property(e => e.NetPay).HasColumnName(ColumnConstants.NetPay);
        entity.Property(e => e.StateTax).HasColumnName(ColumnConstants.StateTax);
        entity.Property(e => e.MedicareTax).HasColumnName(ColumnConstants.MedicareTax);
        entity.Property(e => e.FedTax).HasColumnName(ColumnConstants.FedTax);
        entity.Property(e => e.DeferredComp).HasColumnName(ColumnConstants.DeferredComp);
        entity.Property(e => e.DentalInsurance).HasColumnName(ColumnConstants.DentalInsurance);
        entity.Property(e => e.MedicalInsurance).HasColumnName(ColumnConstants.MedicalInsurance);
        entity.Property(e => e.PensionCont).HasColumnName(ColumnConstants.PensionCont);
        entity.Property(e => e.RetireeTrust).HasColumnName(ColumnConstants.RetireeTrust);
    }
}
