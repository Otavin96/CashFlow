using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCase.Expense.Update;
public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpenseJson request);
}
