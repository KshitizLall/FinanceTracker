using System;

namespace FinanceTracker.BOL.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string TransactionType { get; set; }
    }

    public class CreateTransactionDto
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string TransactionType { get; set; }
    }

    public class UpdateTransactionDto
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string TransactionType { get; set; }
    }

    public class TransactionSummaryDto
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal Balance { get; set; }
    }
}