using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2_4.Models;

namespace WebApp2_4.ModelValidators
{
    public class CommentValidators : AbstractValidator<Comment>
    {
        public CommentValidators(ExpensesDbContext _context)
        {
            RuleFor(x => x.Text).MinimumLength(2);
        }
    }
}
