using TddWorkshop2.Repos;

namespace TddWorkshop2.Services;

public class BudgetService
{
    private readonly IBudgetRepo _budgetRepo;

    public BudgetService(IBudgetRepo budgetRepo)
    {
        _budgetRepo = budgetRepo;
    }

    public decimal Query(DateTime start, DateTime end)
    {
        var daysInMonth = DateTime.DaysInMonth(start.Year, start.Month);
        var daysPeriod = (end - start).Days+1;
        var budgets = _budgetRepo.GetAll();
        var monthBudget = budgets.First(x => x.YearMonth == "202312").Amount;
        if (daysPeriod < daysInMonth)
        {
            return monthBudget * daysPeriod / daysInMonth;
        }
        return monthBudget;
    }
}