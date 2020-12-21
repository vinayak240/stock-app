using CompanyService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Domain.Contracts
{
    public interface IIPOService
    {
        bool AddIPO(IPODto ipo);
        IEnumerable<IPODto> GetIpos();

    }
}
