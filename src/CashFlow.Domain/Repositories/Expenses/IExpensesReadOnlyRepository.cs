using CashFlow.Domain.Entities;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> GetAll();
    Task<Expense?> GetById(long id);

    Task<List<Expense>> FilterByMonth(DateOnly date);
}
