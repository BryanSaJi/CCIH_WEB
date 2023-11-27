using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class PaymentsEnt
    {
        public long PaymentsId { get; set; }
        public string PersonalID { get; set; }
        public DateTime CreationDate { get; set; }
        public Decimal Amount { get; set; }
        public long EmployeeId { get; set; }
        public long PaymentTypeId { get; set; }
        public long IncomeOutcomeId { get; set; }
    }
}