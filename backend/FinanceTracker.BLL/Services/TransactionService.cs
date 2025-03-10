// FinanceTracker.BLL/Services/TransactionService.cs
using FinanceTracker.BOL.DTOs;
using FinanceTracker.BOL.Models;
using FinanceTracker.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync(int userId)
        {
            var transactions = await _transactionRepository.GetTransactionsByUserIdAsync(userId);
            return transactions.Select(MapToDto);
        }

        public async Task<TransactionDto> GetTransactionByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            return transaction != null ? MapToDto(transaction) : null;
        }

        public async Task<TransactionDto> CreateTransactionAsync(int userId, CreateTransactionDto transactionDto)
        {
            var transaction = new Transaction
            {
                Amount = transactionDto.Amount,
                // Convert incoming DateTime to UTC explicitly
                Date = DateTime.SpecifyKind(transactionDto.Date, DateTimeKind.Utc),
                Description = transactionDto.Description,
                CategoryId = transactionDto.CategoryId,
                UserId = userId,
                Type = Enum.Parse<TransactionType>(transactionDto.TransactionType)
            };

            var createdTransaction = await _transactionRepository.AddAsync(transaction);
            return MapToDto(createdTransaction);
        }

        public async Task UpdateTransactionAsync(int id, UpdateTransactionDto transactionDto)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null)
            {
                throw new KeyNotFoundException($"Transaction with ID {id} not found");
            }

            transaction.Amount = transactionDto.Amount;
            transaction.Date = DateTime.SpecifyKind(transactionDto.Date, DateTimeKind.Utc);
            transaction.Description = transactionDto.Description;
            transaction.CategoryId = transactionDto.CategoryId;
            transaction.Type = Enum.Parse<TransactionType>(transactionDto.TransactionType);

            await _transactionRepository.UpdateAsync(transaction);
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _transactionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsByDateRangeAsync(int userId, DateTime startDate, DateTime endDate)
        {
            // Convert dates to UTC
            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);
            
            var transactions = await _transactionRepository.GetTransactionsByDateRangeAsync(userId, startDate, endDate);
            return transactions.Select(MapToDto);
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsByCategoryAsync(int userId, int categoryId)
        {
            var transactions = await _transactionRepository.GetTransactionsByCategoryAsync(userId, categoryId);
            return transactions.Select(MapToDto);
        }

        public async Task<decimal> GetTotalIncomeAsync(int userId, DateTime startDate, DateTime endDate)
        {
            // Convert dates to UTC
            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);
            
            var transactions = await _transactionRepository.GetTransactionsByDateRangeAsync(userId, startDate, endDate);
            return transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount);
        }

        public async Task<decimal> GetTotalExpensesAsync(int userId, DateTime startDate, DateTime endDate)
        {
            // Convert dates to UTC
            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);
            
            var transactions = await _transactionRepository.GetTransactionsByDateRangeAsync(userId, startDate, endDate);
            return transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);
        }

        private TransactionDto MapToDto(Transaction transaction)
        {
            return new TransactionDto
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description,
                CategoryId = transaction.CategoryId,
                CategoryName = transaction.Category?.Name,
                TransactionType = transaction.Type.ToString()
            };
        }
    }
}