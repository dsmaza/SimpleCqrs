namespace SimpleCqrs.DataAccess
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual Category Category { get; set; }
    }
}
