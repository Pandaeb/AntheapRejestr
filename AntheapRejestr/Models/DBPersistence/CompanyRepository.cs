using AntheapRejestr.DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntheapRejestr.Models.DBPersistence
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyRepository()
        {
        }

        public Guid Add(Company company)
        {
            Guid returnGuid = Guid.Empty;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Person osoba = new Person();
                    osoba.Company = company;
                    osoba.FirstName = "Paweł";
                    osoba.LastName = "Szulc";
                    osoba.PESEL = "12345678901";
                    osoba.CompanyName = company.Name;
                    osoba.NIP = string.Empty;

                    if (company.Partners == null)
                        company.Partners = new List<Person>();

                    company.Partners.Add(osoba);

                    foreach(var representative in company.Representatives)
                    {
                        representative.Company = company;
                    }
                    foreach(var clerk in company.AuthorizedClerks)
                    {
                        clerk.Company = company;
                    }
                    foreach(var partner in company.Partners)
                    {
                        partner.Company = company;
                    }
                    foreach (var account in company.AccountNumbers)
                    {
                        Account accountToCreate = new Account();
                        accountToCreate.Company = company;
                        accountToCreate.Number = account;

                        if (company.Accounts == null)
                            company.Accounts = new List<Account>();

                        company.Accounts.Add(accountToCreate);
                    }

                    returnGuid = (Guid)session.Save(company);
                    try
                    {
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        returnGuid = Guid.Empty;
                    }
                }
                return returnGuid;
            }
        }
    }
}
