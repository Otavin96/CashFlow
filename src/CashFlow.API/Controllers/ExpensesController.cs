using CashFlow.Application.UseCase.Expense.Register;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        var UseCase = new RegisterExpenseUseCase();

        var response = UseCase.Execute(request);
        return Created(string.Empty, response);
    }
}
