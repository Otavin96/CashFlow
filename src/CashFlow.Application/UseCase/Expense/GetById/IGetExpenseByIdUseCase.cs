using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCase.Expense.GetById
{
    public interface IGetExpenseByIdUseCase
    {
        Task<ResponseExpenseJson> Execute(long id);
    }
}
