﻿using CashFlow.Application.UseCase.Expense.GetAll;
using CashFlow.Application.UseCase.Expense.GetById;
using CashFlow.Application.UseCase.Expense.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    //Rota para Cadastrar uma Despesa
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredExpenseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterExpenseUseCase useCase,
        [FromBody] RequestRegisterExpenseJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    // Rota para mostrar todas as despesas
    [HttpGet]
    [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllExpenses(
        [FromServices] IGetAllExpenseUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Expenses.Count != 0)
            return Ok(response);

        return NoContent();
    }

    // Rota para recuperar uma despesa por ID

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

    public async Task<IActionResult> GetById(
        [FromServices] IGetExpenseByIdUseCase useCase,
        [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }
}
