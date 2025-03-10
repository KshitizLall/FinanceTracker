using FinanceTracker.BOL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.DAL.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(int userId);
        Task<IEnumerable<Transaction>> GetTransactionsByDateRangeAsync(int userId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<Transaction>> GetTransactionsByCategoryAsync(int userId, int categoryId);
    }
}