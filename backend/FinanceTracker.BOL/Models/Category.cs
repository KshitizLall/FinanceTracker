namespace FinanceTracker.BOL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public CategoryType Type { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
    }

    public enum CategoryType
    {
        Income,
        Expense
    }
}