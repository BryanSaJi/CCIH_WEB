using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class ChangePwEnt
    {
        public long IdUser { get; set; }
        public string PwNew { get; set; }
        public string PWNow { get; set; }
        public string ConfirmPw { get; set; }
    }
}