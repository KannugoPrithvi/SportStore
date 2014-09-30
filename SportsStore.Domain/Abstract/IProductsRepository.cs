using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Category> Categories { get; }
        IEnumerable<ProductCategory> ProductCategories { get; }

        IEnumerable<Image> Images { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);
    }
}
