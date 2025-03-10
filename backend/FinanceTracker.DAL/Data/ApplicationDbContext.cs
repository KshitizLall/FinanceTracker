// FinanceTracker.DAL/Data/ApplicationDbContext.cs
using FinanceTracker.BOL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<FinancialGoal> FinancialGoals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Budgets)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Budget>()
                .HasOne(b => b.User)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<FinancialGoal>()
                .HasOne(g => g.User)
                .WithMany(u => u.FinancialGoals)
                .HasForeignKey(g => g.UserId);

            // Seed default categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Salary", Icon = "money", Type = CategoryType.Income },
                new Category { Id = 2, Name = "Freelance", Icon = "laptop", Type = CategoryType.Income },
                new Category { Id = 3, Name = "Food", Icon = "food", Type = CategoryType.Expense },
                new Category { Id = 4, Name = "Transportation", Icon = "car", Type = CategoryType.Expense },
                new Category { Id = 5, Name = "Housing", Icon = "home", Type = CategoryType.Expense },
                new Category { Id = 6, Name = "Entertainment", Icon = "movie", Type = CategoryType.Expense },
                new Category { Id = 7, Name = "Healthcare", Icon = "heart", Type = CategoryType.Expense },
                new Category { Id = 8, Name = "Education", Icon = "book", Type = CategoryType.Expense }
            );
        }
    }
}