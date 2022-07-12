using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace AntheapRejestr.Models.DBMapping
{
    public class CompanyMap : ClassMap<Company>
    {
        //public Dictionary<string, VATStatus> dict = new Dictionary<string, VATStatus> {
        //    { "Czynny", VATStatus.Czynny },
        //    { "Zwolniony", VATStatus.Zwolniony },
        //    { "Niezarejestrowany", VATStatus.Niezarejestrowany}
        //};

        public CompanyMap()
        {
            Table("Company");

            Id(x => x.Id).GeneratedBy.GuidComb();

            Map(x => x.Name);
            Map(x => x.NIP);
            Map(x => x.StatusVat).CustomType<GenericEnumMapper<VATStatus>>();
            Map(x => x.Regon);
            Map(x => x.Pesel);
            Map(x => x.KRS);
            Map(x => x.ResidenceAddress);
            Map(x => x.WorkingAddress);
            Map(x => x.RegistrationLegalDate);
            Map(x => x.RegistrationDenialDate);
            Map(x => x.RegistrationDenialBasis);
            Map(x => x.RestorationDate);
            Map(x => x.RestorationBasis);
            Map(x => x.RemovalDate);
            Map(x => x.RemovalBasis);
            Map(x => x.HasVirtualAccounts);

            HasMany(x => x.AuthorizedClerks).Cascade.SaveUpdate(); 
            HasMany(x => x.Representatives).Cascade.SaveUpdate(); 
            HasMany(x => x.Partners).Cascade.SaveUpdate().Inverse(); 
            HasMany(x => x.Accounts).Cascade.SaveUpdate();
        }
    }
}
