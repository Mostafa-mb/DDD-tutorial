﻿using Clean_arch.Domain.Orders;

namespace Clean_arch.Domain.Products.Repository
{
    public interface IProductRepository
    {
        List<Product> GetList();
        Product GetById(long id);
        void Add(Product product);
        void Update(Product product);
        void Save();
        void Remove(Product product);
        bool IsProductExist(long id);
    }
}
