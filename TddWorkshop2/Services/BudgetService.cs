using System.Collections;
using TddWorkshop2.Models;
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
        var budgetSummaries = new BudgetSummaries(_budgetRepo.GetAll());
        return budgetSummaries.GetCrossMonthBudget(daysPeriod, daysInMonth, start, end);
    }
}

public class BudgetSummaries
{
    public List<Budget> BudgetList { get; }

    public BudgetSummaries(List<Budget> budgetList)
    {
        BudgetList = budgetList;
    }

    public int GetMonthBudget(string queeryMonth)
    {
        return BudgetList.First(x => x.YearMonth == queeryMonth).Amount;
    }

    public decimal GetBudget(int daysPeriod, int daysInMonth, string queryMonth)
    {
        var monthBudget = GetMonthBudget(queryMonth);
        if (daysPeriod < daysInMonth)
        {
            return monthBudget * daysPeriod / daysInMonth;
        }

        return monthBudget;
    }

    public decimal GetCrossMonthBudget(int daysPeriod, int daysInMonth, DateTime start, DateTime end)
    {
        if (IsSameMonth(start, end))
        {
            return GetBudget(daysPeriod, daysInMonth, start.ToString("yyyyMM"));
        }
   
        return 0;    
    }

    private static bool IsSameMonth(DateTime start, DateTime end)
    {
        return start.Year == end.Year && start.Month == end.Month;
    }
}
