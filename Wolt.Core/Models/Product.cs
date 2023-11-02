using System;
using Wolt.Core.Enums;
using Wolt.Core.Models.BaseModels;

namespace Wolt.Core.Models
{
	public class Product:BaseModel
	{
		static int _id;
	   public string Title { get; set; }
	   public string Description { get; set; }
	   public double Price { get; set; }
	   public double DiscountPrice { get; set; }
	   public ProductCategory ProductCategory { get; set; }

		public Product(string title,string description, double price, double discountPrice, ProductCategory productCategory)
		{
			_id++;
			//string categoryName = ProductCategory.ToString();
            
			Title = title;
			Description = description;
			Price = price;
			DiscountPrice = discountPrice;
			ProductCategory = productCategory;
            Id = $"{ProductCategory.ToString()[0]}-{_id}";
        }
    }
}

