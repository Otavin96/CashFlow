using CashFlow.Application.UseCase.Expense.Register;
<<<<<<< HEAD
using CashFlow.Communication.Requests;
=======
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using Shouldly;
using Xunit.Sdk;

namespace Validators.Tests.Expenses.Register;
>>>>>>> 095020e2cf162e58cda9d02636e906491dfd641e

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
<<<<<<< HEAD

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
=======
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("       ")]
    [InlineData(null)]
    public void Error_Title_Empty(string title)
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = title;

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
        () => result.Errors.ShouldHaveSingleItem(),
        () => result.Errors.Single().ErrorMessage.ShouldBe(ResourceErrorMessages.TITLE_REQUIRED)
    );
    }

    [Fact]
    public void Error_Date_Future()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
        () => result.Errors.ShouldHaveSingleItem(),
        () => result.Errors.Single().ErrorMessage.ShouldBe(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE)
    );
    }

    [Fact]
    public void Error_Payment_Type_Invalid()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)700;

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
        () => result.Errors.ShouldHaveSingleItem(),
        () => result.Errors.Single().ErrorMessage.ShouldBe(ResourceErrorMessages.PAYMENT_TYPE_INVALID)
    );
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-7)]
    public void Error_Amount_Invalid(decimal amount)
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
        () => result.Errors.ShouldHaveSingleItem(),
        () => result.Errors.Single().ErrorMessage.ShouldBe(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO)
    );
    }

>>>>>>> 095020e2cf162e58cda9d02636e906491dfd641e
}
