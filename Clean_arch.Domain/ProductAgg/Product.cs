using Clean_arch.Domain.ProductAgg;
using Clean_arch.Domain.Shared;
using Clean_arch.Domain.Shared.Exceptions;

namespace Clean_arch.Domain.Products
{
    public class Product : AggregateRoot
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public Money Price { get; private set; }
        public ICollection<ProductImages>  Images { get; private set; }

        public Product(string title , Money price)
        {
            Guard(title);
            this.Title = title;
            this.Price = price;
            Id = Id;
        }


        public void Edit(string title , Money price )
        {
            Guard(title);
            this.Title = title;
            this.Price = price;
        }

        public void RemoveImages(long id)
        {
            var image = Images.FirstOrDefault(p => p.Id == id);
            if(image == null)
            {
                throw new Exception("No Image!!");
            }
            Images.Remove(image);
        }

        public void AddImages(string imageName)
        {
            Images.Add(new ProductImages(Id,imageName));
        }

        private static void Guard(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        }
    }
}
