﻿using Clean_arch.Domain.ProductAgg;
using Clean_arch.Domain.Products;
using Clean_arch.Domain.Shared;

namespace Clean_arch.Domain.Test.Unit.Builder
{
    public class ProductBuilder
    {
        private string _title = "test";
        private Money _money = new Money(10000);


        public ProductBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }
        
        public ProductBuilder SetMoney(int rialPrice)
        {
            _money = new Money(rialPrice);
            return this;
        }



        public Product Build()
        {
            return new Product(_title, _money);
        }

    }
}
