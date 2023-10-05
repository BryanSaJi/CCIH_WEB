using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class ChangePasswordEnt
    {
        public long UserID { get; set; }
        public string NewPw { get; set; }
        public string CurrentPW { get; set; }
        public string ConfirmPw { get; set; }
    }
}