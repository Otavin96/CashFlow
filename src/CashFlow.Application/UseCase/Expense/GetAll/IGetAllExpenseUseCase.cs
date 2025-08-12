using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCase.Expense.GetAll
{
    public interface IGetAllExpenseUseCase
    {
        Task<ResponseExpensesJson> Execute();
    }
}
