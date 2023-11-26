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
        public DateTime TimeMark { get; set; }
        public string UserName { get; set; }
        public DateTime LastActivity { get; set; }
        public Nullable<long> IdRol { get; set; }
        public int UserId { get; set; }
        public int buttonId { get; set; }

        public string StatusName { get; set; }

        public Nullable<long> StatusId { get; set; }

        public string CourseName { get; set; }
        public long GroupId { get; set; }

        public string Course { get; set; }
        public string Modality { get; set; }
        public string Group { get; set; }
        public string level { get; set; }
        public string Schedule { get; set; }

        public int CourseId { get; set; }
        public int LevelCourseId { get; set; }
        public long ModalityId { get; set; }
        public long ScheduleId { get; set; }
        public int TimeMarkID { get; set; }

        public int Office_SH_ID { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        public int Day { get; set; }
        public int TotalWorkHours { get; set; }

        public DateTime StartDay { get; set; }
        public DateTime EndDate { get; set; }

    }
}