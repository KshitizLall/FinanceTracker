namespace FinanceTracker.BOL.Models
{
    public class FinancialGoal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime TargetDate { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}