using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCase.Expense.Delete;
using CashFlow.Application.UseCase.Expense.GetAll;
using CashFlow.Application.UseCase.Expense.GetById;
using CashFlow.Application.UseCase.Expense.Register;
using CashFlow.Application.UseCase.Expense.Reports.Excel;
using CashFlow.Application.UseCase.Expense.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCase(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { cfg.AddProfile<AutoMapping>(); });
    }

    private static void AddUseCase(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetAllExpenseUseCase, GetAllExpenseUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseByIdUseCase, DeleteExpenseByIdUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpensesReportExcelUseCase>();
    }

}
