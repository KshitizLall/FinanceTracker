using System;

namespace FinanceTracker.BOL.DTOs
{
    public class FinancialGoalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime TargetDate { get; set; }
        public bool IsCompleted { get; set; }
        public decimal ProgressPercentage { get; set; }
        public int DaysRemaining { get; set; }
    }

    public class CreateFinancialGoalDto
    {
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime TargetDate { get; set; }
    }

    public class UpdateFinancialGoalDto
    {
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime TargetDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}