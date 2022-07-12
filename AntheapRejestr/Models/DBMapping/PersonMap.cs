using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace AntheapRejestr.Models.DBMapping
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("Person");

            Id(x => x.Id).GeneratedBy.GuidComb();

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.NIP);
            Map(x => x.PESEL);
            Map(x => x.CompanyName);

            References(x => x.Company).Column("CompanyId");
        }
    }
}
