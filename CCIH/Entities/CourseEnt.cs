using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class CourseEnt
    {
        public long CourseID { get; set; }
        public string Name { get; set; }
        public int DurationWeeks { get; set; }
        public string Description { get; set; }
        public long ModalityID { get; set; }
        public long LevelCourseID { get; set; }
        public string image { get; set; }
        public string ModalityName { get; set; }
        public string LevelCourseName { get; set; }
        public long status { get; set; }
    }
}