using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class PaycheckTableConfig : IEntityTypeConfiguration<PaycheckTableDto>
{
    public void Configure(EntityTypeBuilder<PaycheckTableDto> entity)
    {
        entity.ToTable(TableConstants.Paychecks);

        // CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // DateRangeFields
        entity.ConfigureDateRange(e => e.DateRange);

        // Paycheck-specific fields
        entity.Property(e => e.Source).HasColumnName(TableColumnConstants.Source);
        entity.Property(e => e.CheckDate).HasColumnName(TableColumnConstants.CheckDate);
        entity.Property(e => e.HoursPaid).HasColumnName(TableColumnConstants.HoursPaid);
        entity.Property(e => e.PayRate).HasColumnName(TableColumnConstants.PayRate);
        entity.Property(e => e.OvertimeHours).HasColumnName(TableColumnConstants.OvertimeHours);
        entity.Property(e => e.HolidayUsed).HasColumnName(TableColumnConstants.HolidayUsed);
        entity.Property(e => e.FixedFloatingHoliday).HasColumnName(TableColumnConstants.FixedFloatingHoliday);
        entity.Property(e => e.GrossEarnings).HasColumnName(TableColumnConstants.GrossEarnings);
        entity.Property(e => e.TaxableGross).HasColumnName(TableColumnConstants.TaxableGross);
        entity.Property(e => e.TotalTaxes).HasColumnName(TableColumnConstants.TotalTaxes);
        entity.Property(e => e.TotalDeductions).HasColumnName(TableColumnConstants.TotalDeductions);
        entity.Property(e => e.NetPay).HasColumnName(TableColumnConstants.NetPay);
        entity.Property(e => e.StateTax).HasColumnName(TableColumnConstants.StateTax);
        entity.Property(e => e.MedicareTax).HasColumnName(TableColumnConstants.MedicareTax);
        entity.Property(e => e.FedTax).HasColumnName(TableColumnConstants.FedTax);
        entity.Property(e => e.DeferredComp).HasColumnName(TableColumnConstants.DeferredComp);
        entity.Property(e => e.DentalInsurance).HasColumnName(TableColumnConstants.DentalInsurance);
        entity.Property(e => e.MedicalInsurance).HasColumnName(TableColumnConstants.MedicalInsurance);
        entity.Property(e => e.PensionCont).HasColumnName(TableColumnConstants.PensionCont);
        entity.Property(e => e.RetireeTrust).HasColumnName(TableColumnConstants.RetireeTrust);

        // Union / Benefits
        entity.Property(e => e.AtDuesIbt).HasColumnName(TableColumnConstants.AtDuesIbt);
        entity.Property(e => e.AtSuppDd).HasColumnName(TableColumnConstants.AtSuppDd);
        entity.Property(e => e.AtSuppLife).HasColumnName(TableColumnConstants.AtSuppLife);
        entity.Property(e => e.AtSurviveBen).HasColumnName(TableColumnConstants.AtSurviveBen);
        entity.Property(e => e.DefComp457401a).HasColumnName(TableColumnConstants.DefComp457401a);
        entity.Property(e => e.PbDppoBTx).HasColumnName(TableColumnConstants.PbDppoBTx);
        entity.Property(e => e.Fmla).HasColumnName(TableColumnConstants.Fmla);
        entity.Property(e => e.PbKaiserBTax).HasColumnName(TableColumnConstants.PbKaiserBTax);
        entity.Property(e => e.PbLifeCoPd).HasColumnName(TableColumnConstants.PbLifeCoPd);
        entity.Property(e => e.PbPension).HasColumnName(TableColumnConstants.PbPension);
        entity.Property(e => e.PbStDis).HasColumnName(TableColumnConstants.PbStDis);
        entity.Property(e => e.PbSurviveB).HasColumnName(TableColumnConstants.PbSurviveB);
        entity.Property(e => e.PbVisionGen).HasColumnName(TableColumnConstants.PbVisionGen);
        entity.Property(e => e.PbWcCler).HasColumnName(TableColumnConstants.PbWcCler);

        // Accruals
        entity.Property(e => e.HolidayEarned).HasColumnName(TableColumnConstants.HolidayEarned);
        entity.Property(e => e.HolidayTaken).HasColumnName(TableColumnConstants.HolidayTaken);
        entity.Property(e => e.HolidayAdjust).HasColumnName(TableColumnConstants.HolidayAdjust);
        entity.Property(e => e.HolidayCurrent).HasColumnName(TableColumnConstants.HolidayCurrent);
        entity.Property(e => e.SickEarned).HasColumnName(TableColumnConstants.SickEarned);
        entity.Property(e => e.SickTaken).HasColumnName(TableColumnConstants.SickTaken);
        entity.Property(e => e.SickAdjust).HasColumnName(TableColumnConstants.SickAdjust);
        entity.Property(e => e.SickCurrent).HasColumnName(TableColumnConstants.SickCurrent);
        entity.Property(e => e.VacationEarned).HasColumnName(TableColumnConstants.VacationEarned);
        entity.Property(e => e.VacationTaken).HasColumnName(TableColumnConstants.VacationTaken);
        entity.Property(e => e.VacationAdjust).HasColumnName(TableColumnConstants.VacationAdjust);
        entity.Property(e => e.VacationCurrent).HasColumnName(TableColumnConstants.VacationCurrent);
    }
}
