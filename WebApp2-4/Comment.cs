using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2_4.Models;

namespace WebApp2_4
{
    public class Comment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }

        public Expense Expense { get; set; }
    }
}
