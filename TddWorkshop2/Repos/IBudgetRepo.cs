using TddWorkshop2.Models;

namespace TddWorkshop2.Repos;

public interface IBudgetRepo
{
    List<Budget> GetAll();
}