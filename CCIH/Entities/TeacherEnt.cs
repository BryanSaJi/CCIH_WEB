using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class TeacherEnt
    {

        public string PersonalID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecLastName { get; set; }
        public string Email { get; set; }
        public string TimeMark { get; set; }

        public string Course { get; set; }
        public string Modality { get; set; }
        public string Group { get; set; }
        public string level { get; set; }
        public string Schedule { get; set; }

        public int CourseId { get; set; }
        public int LevelCourseId { get; set; }
        public long ModalityId { get; set; }
        public long ScheduleId { get; set; }
        public long TimeMarkID { get; set; }




    }
}