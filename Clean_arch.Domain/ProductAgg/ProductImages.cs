using Clean_arch.Domain.Shared;

namespace Clean_arch.Domain.ProductAgg
{
    public class ProductImages : BaseEntity
    {
        public ProductImages(long productId, string imageName)
        {
            if(string.IsNullOrEmpty(imageName))
            {
                throw new Exception("Error!");
            }
            ProductId = productId;
            ImageName = imageName;
        }

        public long ProductId { get; private set; }
        public long Id { get; private set; }
        public string ImageName { get; private set; }
    }
}
