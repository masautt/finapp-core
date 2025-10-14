using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class PaycheckConfig : IEntityTypeConfiguration<PaycheckDto>
{
    public void Configure(EntityTypeBuilder<PaycheckDto> entity)
    {
        entity.ToTable(TableConstants.Paychecks);

        // CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // DateRangeFields
        entity.ConfigureDateRange(e => e.DateRange);

        // Paycheck-specific fields
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

        // Union / Benefits
        entity.Property(e => e.AtDuesIbt).HasColumnName(ColumnConstants.AtDuesIbt);
        entity.Property(e => e.AtSuppDd).HasColumnName(ColumnConstants.AtSuppDd);
        entity.Property(e => e.AtSuppLife).HasColumnName(ColumnConstants.AtSuppLife);
        entity.Property(e => e.AtSurviveBen).HasColumnName(ColumnConstants.AtSurviveBen);
        entity.Property(e => e.DefComp457401a).HasColumnName(ColumnConstants.DefComp457401a);
        entity.Property(e => e.PbDppoBTx).HasColumnName(ColumnConstants.PbDppoBTx);
        entity.Property(e => e.Fmla).HasColumnName(ColumnConstants.Fmla);
        entity.Property(e => e.PbKaiserBTax).HasColumnName(ColumnConstants.PbKaiserBTax);
        entity.Property(e => e.PbLifeCoPd).HasColumnName(ColumnConstants.PbLifeCoPd);
        entity.Property(e => e.PbPension).HasColumnName(ColumnConstants.PbPension);
        entity.Property(e => e.PbStDis).HasColumnName(ColumnConstants.PbStDis);
        entity.Property(e => e.PbSurviveB).HasColumnName(ColumnConstants.PbSurviveB);
        entity.Property(e => e.PbVisionGen).HasColumnName(ColumnConstants.PbVisionGen);
        entity.Property(e => e.PbWcCler).HasColumnName(ColumnConstants.PbWcCler);

        // Accruals
        entity.Property(e => e.HolidayEarned).HasColumnName(ColumnConstants.HolidayEarned);
        entity.Property(e => e.HolidayTaken).HasColumnName(ColumnConstants.HolidayTaken);
        entity.Property(e => e.HolidayAdjust).HasColumnName(ColumnConstants.HolidayAdjust);
        entity.Property(e => e.HolidayCurrent).HasColumnName(ColumnConstants.HolidayCurrent);
        entity.Property(e => e.SickEarned).HasColumnName(ColumnConstants.SickEarned);
        entity.Property(e => e.SickTaken).HasColumnName(ColumnConstants.SickTaken);
        entity.Property(e => e.SickAdjust).HasColumnName(ColumnConstants.SickAdjust);
        entity.Property(e => e.SickCurrent).HasColumnName(ColumnConstants.SickCurrent);
        entity.Property(e => e.VacationEarned).HasColumnName(ColumnConstants.VacationEarned);
        entity.Property(e => e.VacationTaken).HasColumnName(ColumnConstants.VacationTaken);
        entity.Property(e => e.VacationAdjust).HasColumnName(ColumnConstants.VacationAdjust);
        entity.Property(e => e.VacationCurrent).HasColumnName(ColumnConstants.VacationCurrent);
    }
}
