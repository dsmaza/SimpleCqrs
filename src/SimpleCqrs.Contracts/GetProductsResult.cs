using System.Collections.Generic;

namespace SimpleCqrs.Contracts
{
    public class GetProductsResult
    {
        public IEnumerable<GetProductsItem> Items { get; set; }
    }
}
