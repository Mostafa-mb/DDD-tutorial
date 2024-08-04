using Clean_arch.Domain.Shared;

namespace Clean_arch.Domain.Products
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public Money Price { get; private set; }

        public Product(string title , Money price)
        {
            Guard(title);
            this.Title = title;
            this.Price = price;
            Id = Guid.NewGuid();
        }


        public void Edit(string title , Money price )
        {
            Guard(title);
            this.Title = title;
            this.Price = price;
        }

        private static void Guard(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title");
            }
        }
    }
}
