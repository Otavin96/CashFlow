using CashFlow.Application.UseCase.Expense.Register;
using CashFlow.Communication.Requests;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {

        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJson
        {
            Amount = 100,
            Date = DateTime.Now.AddDays(-1),
            Description = "Description",
            PaymentType = CashFlow.Communication.Enums.PaymentType.CreditCard,
            Title = "Apple",
        };

        //Act
        var result = validator.Validate(request);

        //Assert
        Assert.True(result.IsValid);
    }
}
