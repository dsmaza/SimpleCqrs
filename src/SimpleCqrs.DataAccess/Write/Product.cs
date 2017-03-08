using System.Collections.Generic;

namespace SimpleCqrs.DataAccess
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
