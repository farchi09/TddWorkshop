using FluentAssertions;
using NSubstitute;
using TddWorkshop2.Repos;
using TddWorkshop2.Services;

namespace TddWorkshop2.UnitTest;

public class Tests
{
    private BudgetService _budgetService = null!;
    private IBudgetRepo _budgetRepo = null!;

    [SetUp]
    public void Setup()
    {
        _budgetRepo = Substitute.For<IBudgetRepo>();
        _budgetService = new BudgetService(_budgetRepo);
    }

    [Test]
    public void Query_Whole_Month()
    {
        GivenBudgetList();
        var query = _budgetService.Query(new DateTime(2023,12,01), new DateTime(2023, 12,31));
        query.Should().Be(3100);
    }

    [Test]
    public void Query_Partial_Month()
    {
        GivenBudgetList();
        var query = _budgetService.Query(new DateTime(2023,12,01), new DateTime(2023, 12,05));
        query.Should().Be(500);
    }
    
    private void GivenBudgetList()
    {
        _budgetRepo.GetAll().Returns(new List<Budget>()
        {
            new Budget()
            {
                YearMonth = "202312",
                Amount = 3100
            }
        });
    }
}