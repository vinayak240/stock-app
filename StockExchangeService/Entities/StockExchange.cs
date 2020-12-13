using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//1.Id
//2.Stock Exchange
//3.Brief
//4.Contact Address
//5.Remarks

namespace StockExchangeService.Entities
{
    public class StockExchange
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Remarks { get; set; }

    }
}
