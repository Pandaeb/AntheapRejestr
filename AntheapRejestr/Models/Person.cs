using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntheapRejestr.Models
{
    public class Person
    {
        public virtual Guid Id { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string NIP { get; set; }
        public virtual string PESEL { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual Company Company { get; set; }
    }
}
