using Clean_arch.Domain.Shared;
using Clean_arch.Domain.Shared.Exceptions;

namespace Clean_arch.Domain.ProductAgg
{
    public class ProductImages : BaseEntity
    {
        public ProductImages(long productId, string imageName)
        {

            NullOrEmptyDomainDataException.CheckString(imageName, "ImageName");

            ProductId = productId;
            ImageName = imageName;
        }

        public long ProductId { get; private set; }
        public long Id { get; private set; }
        public string ImageName { get; private set; }
    }
}
