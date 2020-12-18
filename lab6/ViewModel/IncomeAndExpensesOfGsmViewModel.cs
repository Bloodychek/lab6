using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab6.ViewModel
{
    public class IncomeAndExpensesOfGsmViewModel
    {
        public int IncomeAndExpenseOfGsmid { get; set; }
        public int? NumberOfCapacity { get; set; }
        public int? ContainerId { get; set; }
        public int? IncomeOrExpensePerliter { get; set; }
        public DateTime DateAndTimeOfTheOperationIncomeOrExpense { get; set; }
        public int? StaffId { get; set; }
        public string ResponsibleForTheOperation { get; set; }
        public string FullName { get; set; }
    }
}
