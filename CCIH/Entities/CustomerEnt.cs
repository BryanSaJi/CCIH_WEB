using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class CustomerEnt
    {
        public int CustomerId { get; set; }
        public String PersonalID { get; set;}
        public String Email { get; set; }
        public string Name { get; set;}
        public string LastName { get; set; }
        public string SecLastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public int IdRol { get; set; }
        public int IdentificationsId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string Course { get; set; }
        public string Modality { get; set; }
        public string Nivel { get; set; }
        public string Schedule { get; set; }

        public int CourseId { get; set; }
        public int ModalityId { get; set; }
        public int LevelCourseId { get; set; }

    }
}