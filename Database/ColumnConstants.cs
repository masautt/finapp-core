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
    public const string TotalCar = "total_car";

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

}