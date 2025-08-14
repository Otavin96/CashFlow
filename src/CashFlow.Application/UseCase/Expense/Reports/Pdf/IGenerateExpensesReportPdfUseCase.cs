namespace CashFlow.Application.UseCase.Expense.Reports.Excel;
public interface IGenerateExpensesReportPdfUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
