using Microsoft.EntityFrameworkCore;


namespace WebApp2_4.Models
{
    public class ExpensesDbContext: DbContext
    {
        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }
}
