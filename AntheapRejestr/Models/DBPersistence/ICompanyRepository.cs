using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntheapRejestr.Models.DBPersistence
{
    public interface ICompanyRepository
    {
        Guid Add(Company company);
    }
}
