using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class GroupEnt
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public int StudentsNumber { get; set; }
        public int MaxStudentsNumber { get; set; }
        public long CourseId { get; set; }
        public long ScheduleId { get; set; }
        public long TeacherId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public string ScheduleDescription { get; set; }


    }
}