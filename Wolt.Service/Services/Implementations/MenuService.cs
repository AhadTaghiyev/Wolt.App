using Wolt.Core.Enums;
using Wolt.Service.Services.Interfaces;
namespace Wolt.Service.Services.Implementations
{
	public class MenuService
	{
        IProductService productService = new ProductService();
        public async Task RunApp()
        {
            await Menu();
            string request = Console.ReadLine();
            while (request != "0")
            {
                switch (request)
                {
                    case "1":
                        await CreateProduct();
                        break;
                    case "2":
                        await UpdateProduct();
                        break;
                    case "3":
                        await RemoveProduct();
                        break;
                    case "4":
                        await Get();
                        break;
                    case "5":
                        await GetAllProduct();
                        break;
                    default:
                        break;
                }

                await Menu();
                request = Console.ReadLine();
            }
        }
        async Task CreateProduct()
{
    Console.WriteLine("add title");
    string Title = Console.ReadLine();
    Console.WriteLine("add desc");
    string Description = Console.ReadLine();
    Console.WriteLine("add price");
    double.TryParse(Console.ReadLine(), out double Price);
    Console.WriteLine("add discountprice");
    double.TryParse(Console.ReadLine(), out double DiscountPrice);
    int i = 1;
    foreach (var item in Enum.GetValues(typeof(ProductCategory)))
    {
        Console.WriteLine($"{i}.{item}");
        i++;
    }

    bool IsExsist;
    int EnumIndex;
    do
    {
        Console.WriteLine("Add ProductCategory");
        int.TryParse(Console.ReadLine(), out EnumIndex);
        IsExsist = Enum.IsDefined(typeof(ProductCategory), (ProductCategory)EnumIndex);
    } while (!IsExsist);

    string result = await productService.CreateAsync(Title, Description, Price, DiscountPrice, (ProductCategory)EnumIndex);
    Console.WriteLine(result);
}
        async Task UpdateProduct()
        {
            Console.WriteLine("add Id");
            string Id = Console.ReadLine();
            Console.WriteLine("add title");
            string Title = Console.ReadLine();
            Console.WriteLine("add desc");
            string Description = Console.ReadLine();
            Console.WriteLine("add price");
            double.TryParse(Console.ReadLine(), out double Price);
            Console.WriteLine("add discountprice");
            double.TryParse(Console.ReadLine(), out double DiscountPrice);
            int i = 1;
            foreach (var item in Enum.GetValues(typeof(ProductCategory)))
            {
                Console.WriteLine($"{i}.{item}");
                i++;
            }

            bool IsExsist;
            int EnumIndex;
            do
            {
                Console.WriteLine("Add ProductCategory");
                int.TryParse(Console.ReadLine(), out EnumIndex);
                IsExsist = Enum.IsDefined(typeof(ProductCategory), (ProductCategory)EnumIndex);
            } while (!IsExsist);

            string result = await productService.UpdateAsync(Id,Title, Description, Price, DiscountPrice, (ProductCategory)EnumIndex);
            Console.WriteLine(result);
        }
        async Task RemoveProduct()
        {
            Console.WriteLine("add Id");
            string Id = Console.ReadLine();
          string result= await productService.RemoveAsync(Id);
            Console.WriteLine(result);
        }
        async Task GetAllProduct()
        {
            await productService.GetAllAsync();
        }
        async Task Get()
        {
            Console.WriteLine("add Id");
            string Id = Console.ReadLine();
            string result =await productService.GetAsync(Id);
            Console.WriteLine(result);
        }
        async Task Menu()
{
    Console.WriteLine("1.Create");
    Console.WriteLine("2.Update");
    Console.WriteLine("3.Remove");
    Console.WriteLine("4.Get");
    Console.WriteLine("5.GetAll");
    Console.WriteLine("0.Close");
}
	}
}

