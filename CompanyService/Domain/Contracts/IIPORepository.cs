using CompanyService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain.Contracts
{
    public interface IIPORepository
    {
        bool AddIPO(IPO ipo);
    }
}
