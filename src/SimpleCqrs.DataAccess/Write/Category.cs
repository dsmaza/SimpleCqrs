using System.Collections.Generic;

namespace SimpleCqrs.DataAccess
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
