using FinanceTracker.BOL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.BLL.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync(int userId);
        Task<TransactionDto> GetTransactionByIdAsync(int id);
        Task<TransactionDto> CreateTransactionAsync(int userId, CreateTransactionDto transactionDto);
        Task UpdateTransactionAsync(int id, UpdateTransactionDto transactionDto);
        Task DeleteTransactionAsync(int id);
        Task<IEnumerable<TransactionDto>> GetTransactionsByDateRangeAsync(int userId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<TransactionDto>> GetTransactionsByCategoryAsync(int userId, int categoryId);
        Task<decimal> GetTotalIncomeAsync(int userId, DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalExpensesAsync(int userId, DateTime startDate, DateTime endDate);
    }
}