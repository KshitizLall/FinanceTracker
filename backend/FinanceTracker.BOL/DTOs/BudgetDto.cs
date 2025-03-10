using System;
using System.Collections.Generic;

namespace FinanceTracker.BOL.DTOs
{
    public class BudgetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class CreateBudgetDto
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateBudgetDto
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CategoryId { get; set; }
    }

    public class BudgetProgressDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal Allocated { get; set; }
        public decimal Spent { get; set; }
        public decimal Remaining { get; set; }
        public decimal PercentUsed { get; set; }
    }

    public class BudgetSummaryDto
    {
        public decimal TotalBudgeted { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal TotalRemaining { get; set; }
        public List<BudgetProgressDto> BudgetItems { get; set; }
    }
}
