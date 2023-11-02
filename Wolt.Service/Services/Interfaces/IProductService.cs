using System;
using Wolt.Core.Enums;

namespace Wolt.Service.Services.Interfaces
{
	public interface IProductService
	{
		public Task<string> CreateAsync(string title,string description,double price,double discountPrice,ProductCategory productCategory);
		public Task<string> UpdateAsync(string id,string title,string description,double price,double discountPrice,ProductCategory productCategory);
		public Task<string> RemoveAsync(string id);
		public Task<string> GetAsync(string id);
		public Task GetAllAsync();
    }
}

