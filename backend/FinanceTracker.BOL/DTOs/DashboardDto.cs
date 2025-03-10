using System;
using System.Collections.Generic;

namespace FinanceTracker.BOL.DTOs
{
     public class DashboardDto
    {
        public TransactionSummaryDto Summary { get; set; }
        public List<CategorySummaryDto> ExpensesByCategory { get; set; }
        public List<CategorySummaryDto> IncomeByCategory { get; set; }
        public List<MonthlyFinanceSummaryDto> MonthlyData { get; set; }
        public List<BudgetProgressDto> BudgetProgress { get; set; }
        public List<FinancialGoalDto> GoalProgress { get; set; }
        public List<RecentTransactionDto> RecentTransactions { get; set; }
    }

    public class MonthlyFinanceSummaryDto
    {
        public string Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Savings { get; set; }
    }

    public class RecentTransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string TransactionType { get; set; }
    }
}