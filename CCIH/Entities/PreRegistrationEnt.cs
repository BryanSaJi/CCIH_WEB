using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class PreRegistrationEnt
    {
        public int PreRegistrationId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecLastName { get; set; }
        public int CourseId { get; set; }
        public int ModalityId { get; set; }
        public int LevelCourseId { get; set; }
        public int StatusId { get; set; }
        public DateTime DatePreRegistration { get; set; }

        public string Course { get; set; }
        public string Modality { get; set; }
        public string Level { get; set; }
        public string Status { get; set; }

    }
}
