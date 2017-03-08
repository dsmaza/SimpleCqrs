using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCqrs.Contracts
{
    public class UpdateProduct
    {
        public decimal Price { get; set; }
        public string Title { get; set; }
    }
}
