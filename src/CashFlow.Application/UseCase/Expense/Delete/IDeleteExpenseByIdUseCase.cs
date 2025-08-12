using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCase.Expense.Delete;
public interface IDeleteExpenseByIdUseCase
{
    Task Execute(long id);
}
