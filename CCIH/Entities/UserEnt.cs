using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class UserEnt
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserPw { get; set; }
        public long OfficeId { get; set; }
        public long CustomerId { get; set; }
        public long IdRol { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActivity { get; set; }
        public long UserModificationId { get; set; }
        public DateTime ModificationID { get; set; }
        public long StatusId { get; set; }
        public string NameRol { get; set; }
        public string Token { get; set; }

    }
}