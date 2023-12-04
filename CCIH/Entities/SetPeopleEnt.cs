using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CCIH.Entities
{
    public class SetPeopleEnt
    {

        public List<GroupEnt> Groups { get; set; }
        public List<UserEnt> StudentsInGroup { get; set; }
        public List<UserEnt> StudentsOutGroup { get; set; }
        public GroupEnt GroupEnt { get; set; }

    }
}