using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinancialManagement.Models
{
    public class ConstantSpending
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public ConstantSpendingPeriod SpendingPeriod { get; set; }
    }
}
