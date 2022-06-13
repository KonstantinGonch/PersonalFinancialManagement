using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinancialManagement.Models
{
    public class SavingGoal
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Не назначен пользователь")]
        public long ProfileId { get; set; }

        [Required(ErrorMessage = "Не обозначено целевое количество накоплений")]
        public long Amount { get; set; }

        [Required(ErrorMessage = "Не обозначено начало периода")]
        public DateTime PeriodStart { get; set; }

        [Required(ErrorMessage = "Не обозначено окончание периода")]
        public DateTime PeriodEnd { get; set; }
    }
}
