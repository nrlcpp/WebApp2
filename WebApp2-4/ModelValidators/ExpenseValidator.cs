using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WebApp2_4.Models;

namespace WebApp2_4.ModelValidators
{
    public class ExpenseValidator : AbstractValidator<Expense>
    {
            public ExpenseValidator()
            {
                RuleFor(x => x.Description)
                    .MinimumLength(2)
                    .MaximumLength(70);
                RuleFor(x => x.Sum)
                    .GreaterThan(0);
                RuleFor(x => x.Date)
                    .LessThan(DateTime.Now);
                RuleFor(x => x.Location)
                    .MinimumLength(2)
                    .MaximumLength(30);
        }
        }
    }

