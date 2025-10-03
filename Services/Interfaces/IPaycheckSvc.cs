namespace Services.Interfaces;

public interface IPaycheckSvc
{
    Task<object?> GetLatestTimeOff();
}