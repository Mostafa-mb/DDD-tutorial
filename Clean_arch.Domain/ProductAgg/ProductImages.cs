namespace Clean_arch.Domain.ProductAgg
{
    public class ProductImages
    {
        public ProductImages(Guid productId, string imageName)
        {
            if(string.IsNullOrEmpty(imageName))
            {
                throw new Exception("Error!");
            }
            ProductId = productId;
            ImageName = imageName;
        }

        public Guid ProductId { get; private set; }
        public long Id { get; private set; }
        public string ImageName { get; private set; }
    }
}
