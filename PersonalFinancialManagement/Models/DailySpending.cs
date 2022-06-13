using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinancialManagement.Models
{
    public class DailySpending
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public DateTime Date { get; set; }
        public long Amount { get; set; }
    }
}
