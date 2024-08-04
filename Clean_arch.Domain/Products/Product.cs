﻿namespace Clean_arch.Domain.Products
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public int Price { get; private set; }

        public Product(string title , int price)
        {
            Guard(title, price);
            this.Title = title;
            this.Price = price;
            Id = Guid.NewGuid();
        }


        public void Edit(string title, int price)
        {
            Guard(title, price);
            this.Title = title;
            this.Price = price;
        }

        private static void Guard(string title, int price)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title");
            }
            if (price < 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
