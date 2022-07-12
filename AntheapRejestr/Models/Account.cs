using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntheapRejestr.Models
{
    public class Account
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Number { get; set; }
        public virtual Company Company { get; set; }
    }
}
