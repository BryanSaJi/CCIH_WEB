using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class PaymentsEnt
    {

        public string PersonalID { get; set; }
        public DateTime CreationDate { get; set; }
        public Decimal Amount { get; set; }
        public long EmployeeId { get; set; }
        public long PaymentTypeId { get; set; }
        public long IncomeOutcomeId { get; set; }
        public long ReasonId { get; set; }

        public string CustomName { get; set; }
        public string PaymentType { get; set; }
        public string IncomeOutcome { get; set; }
        public string Motivo { get; set; }
        public string Coment { get; set; }
        public long id_Motive { get; set; }
        public string Comentario { get; set; }
        public string Name { get; set; }
        public long PaymentsId { get; set; }

    }
}