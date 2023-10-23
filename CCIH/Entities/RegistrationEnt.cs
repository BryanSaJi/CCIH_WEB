﻿using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace CCIH.Entities
{
    public class RegistrationEnt
    {
        public int RegistrationId { get; set; }
        public string PersonalID { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Course { get; set; }
        public string Modality { get; set; }
        public string Level { get; set; }
        public string Schedule { get; set; }

        public int CourseId { get; set; }
        public int ModalityId { get; set; }
        public int LevelCourseId { get; set; }
        public int ScheduleId { get; set; }
        public Decimal Amount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int PaymentDay { get; set; }
        public string Comments { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }

        public List<StatusEnt> statusList { get; set; }
        public List<CourseEnt> coursesList { get; set; }
        public List<ModalityEnt> modalityList { get; set;}
        public List<LevelCourseEnt> levelCourseList { get; set; }
        public List<ScheduleEnt> scheduleList { get; set; }
        public List<GroupEnt> groupList { get; set; }



    }
}