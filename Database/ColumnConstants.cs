namespace Database;

public static class ColumnConstants
{
    // Common columns
    public const string CommonId = "CommonId";
    public const string Id = "id";
    public const string Number = "number";
    public const string Comments = "comments";
    public const string Amount = "amount";
    public const string Category = "category";
    public const string CreatedAt = "created_at";
    public const string ModifiedAt = "modified_at";
    public const string StartDate = "start_date";
    public const string EndDate = "end_date";
    public const string Month = "month";
    public const string Year = "year";
    public const string Day = "day";
    public const string Weekday = "weekday";
    public const string Date = "date";

    // Contribution-specific
    public const string Exclude = "exclude";
    public const string Account = "account";

    // Sidegig Specific
    public const string HoursWorked = "hours_worked";
    public const string AmountPaid = "amount_paid";
    public const string Company = "company";

    // Housing Specific
    public const string RentAmount = "rent_amount";
    public const string RentDate = "rent_date";
    public const string InsuranceAmount = "insurance_amount";
    public const string InsuranceDate = "insurance_date";
    public const string PetRent = "pet_rent";
    public const string Fees = "fees";
    public const string UtilitiesDate = "utilities_date";
    public const string Electricity = "electricity";
    public const string Water = "water";
    public const string Gas = "gas";
    public const string Wifi = "wifi";
    public const string CityServices = "city_services";
    public const string TotalUtilities = "total_utilities";
    public const string TotalHousing = "total_housing";

    // Car Specific
    public const string PaymentDate = "payment_date";
    public const string PaymentAmount = "payment_amount";
    public const string Principal = "principal";
    public const string Interest = "interest";
    public const string Owed = "owed";
    public const string StartMiles = "start_miles";
    public const string MilesAdded = "miles_added";
    public const string MilesDate = "miles_date";

    // Paycheck-specific
    public const string Source = "source";
    public const string CheckDate = "check_date";
    public const string HoursPaid = "hours_paid";
    public const string PayRate = "pay_rate";
    public const string OvertimeHours = "overtime_hours";
    public const string HolidayUsed = "holiday_used";
    public const string FixedFloatingHoliday = "fixed_floating_holiday";
    public const string GrossEarnings = "gross_earnings";
    public const string TaxableGross = "taxable_gross";
    public const string TotalTaxes = "total_taxes";
    public const string TotalDeductions = "total_deductions";
    public const string NetPay = "net_pay";
    public const string StateTax = "state_tax";
    public const string MedicareTax = "medicare_tax";
    public const string FedTax = "fed_tax";
    public const string DeferredComp = "deferred_comp";
    public const string DentalInsurance = "dental_insurance";
    public const string MedicalInsurance = "medical_insurance";
    public const string PensionCont = "pension_cont";
    public const string RetireeTrust = "retiree_trust";

    // Investment-specific
    public const string BeginningBalance = "beginning_balance";
    public const string EndingBalance = "ending_balance";
    public const string ChangeInValue = "change_in_value";
    public const string ChangeInPercentage = "change_in_percentage";
    public const string Type = "type";

    // Transaction-specific
    public const string SubCategory = "sub_category";
    public const string Business = "business";
    public const string City = "city";
    public const string State = "state";
    public const string Description = "description";
    public const string Recipient = "recipient";
    public const string Necessity = "necessity";
    public const string Reimburse = "reimburse";
    public const string Recurring = "recurring";
    public const string Ex = "ex";

    // Union / Benefits
    public const string AtDuesIbt = "at_dues_ibt";
    public const string AtSuppDd = "at_supp_dd";
    public const string AtSuppLife = "at_supp_life";
    public const string AtSurviveBen = "at_survive_ben";
    public const string DefComp457401a = "def_comp_457_401a";
    public const string PbDppoBTx = "pb_dppo_btx";
    public const string Fmla = "fmla";
    public const string PbKaiserBTax = "pb_kaiser_btax";
    public const string PbLifeCoPd = "pb_life_co_pd";
    public const string PbPension = "pb_pension";
    public const string PbStDis = "pb_st_dis";
    public const string PbSurviveB = "pb_survive_b";
    public const string PbVisionGen = "pb_vision_gen";
    public const string PbWcCler = "pb_wc_cler";

    // Accruals
    public const string HolidayEarned = "holiday_earned";
    public const string HolidayTaken = "holiday_taken";
    public const string HolidayAdjust = "holiday_adjust";
    public const string HolidayCurrent = "holiday_current";
    public const string SickEarned = "sick_earned";
    public const string SickTaken = "sick_taken";
    public const string SickAdjust = "sick_adjust";
    public const string SickCurrent = "sick_current";
    public const string VacationEarned = "vacation_earned";
    public const string VacationTaken = "vacation_taken";
    public const string VacationAdjust = "vacation_adjust";
    public const string VacationCurrent = "vacation_current";

}