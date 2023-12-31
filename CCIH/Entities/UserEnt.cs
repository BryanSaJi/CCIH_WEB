﻿using CCIH.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Entities
{
    public class UserEnt
    {
        public long UserId { get; set; }
        public string PersonalID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecLastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string UserPw { get; set; }
        public string NewUserPw { get; set; }
        public string ConfirmPw { get; set; }
        public string Phone { get; set; }
        public long IdRol { get; set; }
        public string RolName { get; set; }
        public long IdentificationsId { get; set; }
        public string IdentificationsName { get; set; }
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActivity { get; set; }
        public string Token { get; set; }
        public long EmployeeId { get; set; }

        /*pruba para ver si acomodo los teachers*/

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