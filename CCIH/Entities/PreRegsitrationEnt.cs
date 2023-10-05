using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class PreRegistrationEnt
    {
        public int IdPreRegistration { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Lastname1 { get; set; }
        public string Lastname2 { get; set; }
        public int IdCourse { get; set; }
        public int IdModality { get; set; }
        public int IdLevel { get; set; }
        public int IdState { get; set; }
        public DateTime DatePreRegistration { get; set; }

        public string Course { get; set; }
        public string Modality { get; set; }
        public string Level { get; set; }
        public string State { get; set; }

    }
}