using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntheapRejestr.Models.DBMapping
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Table("Account");

            Id(x => x.Id).GeneratedBy.GuidComb();

            Map(x => x.Number);

            References(x => x.Company).Column("CompanyId");
        }
    }
}
