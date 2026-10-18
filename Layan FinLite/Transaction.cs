using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layan_FinLite
{
    public abstract class Transaction : ISchedulable
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string Type { get; set; } // "Income" or "Expense"

        public abstract void Schedule();
    }
}
