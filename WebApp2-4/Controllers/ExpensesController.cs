﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp2_4.Models;

namespace WebApp2_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpensesDbContext _context;

        public ExpensesController(ExpensesDbContext context)
        {
            _context = context;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses(
            [FromQuery]DateTime? from = null,
            [FromQuery]DateTime? to = null,
            [FromQuery]Models.Type? type = null)
        {
            //Filters results by date
            IQueryable<Expense> result = _context.Expenses;

            if (from != null)
            {
                result = result.Where(e => from <= e.Date);
            }
            if (to != null)
            {
                result = result.Where(e => e.Date <= to);
            }
            if (type !=null)
            {
                result = result.Where(e => e.Type == type);
            }
            //if (from != null && to != null && type != null)
            //{
            //    result = result.Where(e => from <= e.Date && e.Date <= to && e.Type == type);
            //}

                var resultList = await result.ToListAsync();
            return resultList;

        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(long id)
        {
            var expense = await _context.Expenses.
                Include(e => e.Comments)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }

        // PUT: api/Expenses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(long id, Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Expenses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expense>> DeleteExpense(long id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return expense;
        }

        private bool ExpenseExists(long id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
