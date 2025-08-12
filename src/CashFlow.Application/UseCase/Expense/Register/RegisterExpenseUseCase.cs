using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Infrastructure.DataAccess.Repositories;

namespace CashFlow.Application.UseCase.Expense.Register;
public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterExpenseUseCase(
        IExpensesWriteOnlyRepository repository, 
        IUnitOfWork unitOfWork,
        IMapper mapper
        )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;

    }
    public async Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request)
    {
        Validate(request);

        // Change 'Expense' to 'Domain.Entities.Expense' to reference the class, not the namespace
        var entity = _mapper.Map<Domain.Entities.Expense>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredExpenseJson>(entity);
    }

    private void Validate(RequestExpenseJson request)
    {

        var validator = new ExpenseValidator();

        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
        
    }
}
