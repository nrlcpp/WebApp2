using Microsoft.EntityFrameworkCore;
using System;
using WebApp2_4.Models;

namespace WebApp2_4.Models
{
    public class ExpensesDbContext: DbContext
    {
        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }

}
  


               
  
    


