using FinanceTracker.BOL.Models;
using FinanceTracker.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(int userId)
        {
            return await _dbSet
                .Include(t => t.Category)
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByDateRangeAsync(int userId, DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(t => t.Category)
                .Where(t => t.UserId == userId && t.Date >= startDate && t.Date <= endDate)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByCategoryAsync(int userId, int categoryId)
        {
            return await _dbSet
                .Include(t => t.Category)
                .Where(t => t.UserId == userId && t.CategoryId == categoryId)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }
    }
}