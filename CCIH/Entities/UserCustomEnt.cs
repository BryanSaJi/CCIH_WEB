using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class UserCustomEnt
    {
        public long IdUser { get; set; }
        public string User { get; set; }
        public string PwUser { get; set; }
        public long IdCustom { get; set; }
        public String Id { get; set; }
        public String Email { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int IdState { get; set; }
        public int IdRole { get; set; }
        public string NameRole { get; set; }
        public byte[] QRcode { get; set; }
    }
}