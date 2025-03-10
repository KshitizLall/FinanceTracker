using System;
using System.Collections.Generic;

namespace FinanceTracker.BOL.DTOs
{
    public class ReportDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TransactionSummaryDto Summary { get; set; }
        public List<CategorySummaryDto> ExpensesByCategory { get; set; }
        public List<CategorySummaryDto> IncomeByCategory { get; set; }
        public List<MonthlyFinanceSummaryDto> MonthlyData { get; set; }
        public List<BudgetComparisonDto> BudgetComparison { get; set; }
    }

    public class BudgetComparisonDto
    {
        public string CategoryName { get; set; }
        public decimal Budgeted { get; set; }
        public decimal Actual { get; set; }
        public decimal Difference { get; set; }
        public bool IsOverBudget { get; set; }
    }
}