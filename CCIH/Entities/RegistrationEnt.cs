using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class RegistrationEnt
    {
        public int IdRegistration { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Course { get; set; }
        public string Modality { get; set; }
        public string Level { get; set; }
        public string Schedule { get; set; }

        public int IdCourse { get; set; }
        public int IdModality { get; set; }
        public int IdLevel { get; set; }
        public int IdSchedule { get; set; }
        public Decimal Price { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int DayPay { get; set; }
        public string Coment { get; set; }
        public int IdState { get; set; }
        public string Status { get; set; }

    }
}
