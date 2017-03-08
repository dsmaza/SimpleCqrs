namespace SimpleCqrs.Contracts
{
    public class GetProductByIdResult
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string[] Categories { get; set; }
    }
}
