using Microsoft.EntityFrameworkCore;
using System;

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
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Expense>().HasData(
    //    new Expense
    //    {
    //        Description = "First expense",
    //        Sum = 120,
    //        Location = "Auchan",
    //        Date = new DateTime(2020, 03, 11),
    //        Currency = "lei",
    //        Type = Type.utilities

    //    });
          
    //}
}
               
  
    


