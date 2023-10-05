using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class CustomerUserEnt
    {
        public long UserId { get; set; }
        public string User { get; set; }
        public string UserPw { get; set; }
        public long CustomerId { get; set; }
        public String Id { get; set; }
        public String Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecLastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public int IdRol { get; set; }
        public string NameRol { get; set; }
    }
}