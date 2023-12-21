namespace TddWorkshop2.Services;

public class BudgetService
{
    public decimal Query(DateTime start, DateTime end)
    {
        var daysInMonth = DateTime.DaysInMonth(start.Year, start.Month);
        var daysPeriod = (end - start).Days+1;
        if (daysPeriod < daysInMonth)
        {
            return 3100 * daysPeriod / daysInMonth;
        }
        return 3100;
    }
}