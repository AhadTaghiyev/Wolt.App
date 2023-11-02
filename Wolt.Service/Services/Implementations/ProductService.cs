using System;
using Wolt.Core.Enums;
using Wolt.Core.Models;
using Wolt.Core.Repositories;
using Wolt.Data.Repositores;
using Wolt.Service.Services.Interfaces;

namespace Wolt.Service.Services.Implementations
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository = new ProductRepository();

        public async Task<string> CreateAsync(string title, string description, double price, double discountPrice, ProductCategory productCategory)
        {
            if (string.IsNullOrWhiteSpace(title))
                 return "Title can not be empty";

            if (string.IsNullOrWhiteSpace(description))
                return "Description can not be empty";

            if (price <= 0)
                return "Price can not be less than 0";

            if(discountPrice>=price||discountPrice<0)
                return "Price can not be less than 0 and equal discountPrice";

            Product product = new Product(title,description,price,discountPrice,productCategory);
            product.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _productRepository.AddAsync(product);

            return "Successfully created";
        }

        public async Task GetAllAsync()
        {
            List<Product> products =await _productRepository.GetAllAsync();

            foreach (Product product in products)
            {
                Console.WriteLine($"Id:{product.Id} Title:{product.Title} Description:{product.Description} Price:{product.Price} DiscountPrice:{product.DiscountPrice} Category:{product.ProductCategory} CreatedAt:{product.CreatedAt} UpdatedAt:{product.UpdateAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Product product =await _productRepository.GetAsync(x=>x.Id==id);

            if (product == null)
                return "Product not found";

            Console.WriteLine($"Id:{product.Id} Title:{product.Title} Description:{product.Description} Price:{product.Price} DiscountPrice:{product.DiscountPrice} Category:{product.ProductCategory} CreatedAt:{product.CreatedAt} UpdatedAt:{product.UpdateAt}");
            return "Success";
        }

        public async Task<string> RemoveAsync(string id)
        {
            Product product = await _productRepository.GetAsync(x => x.Id == id);

            if (product == null)
                return "Product not found";

           await _productRepository.RemoveAsync(product);

            return "Removed successfully";
        }

        public async Task<string> UpdateAsync(string id,string title, string description, double price, double discountPrice, ProductCategory productCategory)
        {
            Product product = await _productRepository.GetAsync(x => x.Id == id);

            if (product == null)
                return "Product not found";

            if (string.IsNullOrWhiteSpace(title))
                return "Title can not be empty";

            if (string.IsNullOrWhiteSpace(description))
                return "Description can not be empty";

            if (price <= 0)
                return "Price can not be less than 0";

            if (discountPrice >= price || discountPrice < 0)
                return "Price can not be less than 0 and equal discountPrice";



            product.Title = title;
            product.Description = description;
            product.Price = price;
            product.DiscountPrice = discountPrice;
            product.ProductCategory = productCategory;
            product.UpdateAt = DateTime.UtcNow.AddHours(4);

            return "Updated successfully";
        }
    }
}

