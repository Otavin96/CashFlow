using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Application.UseCase.Expense.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        // Change 'Expense' to 'Domain.Entities.Expense' to reference the class, not the namespace
        var entity = new CashFlow.Domain.Entities.Expense
        {
            // You need to initialize the properties here, e.g.:
            // Amount = request.Amount,
            // Description = request.Description,
            // Date = request.Date
            
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
            Title = request.Title,

        };

        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {

        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
        
    }
}
