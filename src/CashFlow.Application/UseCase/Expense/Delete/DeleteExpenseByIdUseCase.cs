
using CashFlow.Domain.Repositories;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Infrastructure.DataAccess.Repositories;

namespace CashFlow.Application.UseCase.Expense.Delete;
public class DeleteExpenseByIdUseCase : IDeleteExpenseByIdUseCase
{
    private readonly IExpensesWriteOnlyRepository _repsotory;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteExpenseByIdUseCase(IExpensesWriteOnlyRepository repsotory, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repsotory = repsotory;
    }
    public async Task Execute(long id)
    {
        var result = await _repsotory.Delete(id);

        if (result == false)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }
}
