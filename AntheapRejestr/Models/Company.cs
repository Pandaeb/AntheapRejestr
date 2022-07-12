using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntheapRejestr.Models
{
    public enum VATStatus
    {
        Czynny,
        Zwolniony,
        Niezarejestrowany
    }

    public class Company
    {
        public virtual Guid Id { get; protected set; }
        public virtual IList<Person> AuthorizedClerks { get; set; }
        public virtual string Regon { get; set; }
        public virtual Nullable<DateTime> RestorationDate { get; set; }
        public virtual string WorkingAddress { get; set; }
        public virtual bool HasVirtualAccounts { get; set; }
        public virtual Nullable<VATStatus> StatusVat { get; set; }
        public virtual string KRS { get; set; }
        public virtual string RestorationBasis { get; set; }
        public virtual IList<string> AccountNumbers { get; set; }
        public virtual IList<Account> Accounts { get; set; }
        public virtual string RegistrationDenialBasis { get; set; }
        public virtual string NIP { get; set; }
        public virtual Nullable<DateTime> RemovalDate { get; set; }
        public virtual IList<Person> Partners { get; set; }
        public virtual string Name { get; set; }
        public virtual Nullable<DateTime> RegistrationLegalDate { get; set; }
        public virtual string RemovalBasis { get; set; }
        public virtual string Pesel { get; set; }
        public virtual IList<Person> Representatives { get; set; }
        public virtual string ResidenceAddress { get; set; }
        public virtual Nullable<DateTime> RegistrationDenialDate { get; set; }
    }
}
