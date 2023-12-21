using FluentAssertions;
using TddWorkshop2.Services;

namespace TddWorkshop2.UnitTest;

public class Tests
{
    private BudgetService _budgetService;

    [SetUp]
    public void Setup()
    {
        _budgetService = new BudgetService();
    }

    [Test]
    public void Query_Whole_Month()
    {
        var query = _budgetService.Query(new DateTime(2023,12,01), new DateTime(2023, 12,31));
        query.Should().Be(3100);
    }
  
    [Test]
    public void Query_Partial_Month()
    {
        var query = _budgetService.Query(new DateTime(2023,12,01), new DateTime(2023, 12,05));
        query.Should().Be(500);
    }
}