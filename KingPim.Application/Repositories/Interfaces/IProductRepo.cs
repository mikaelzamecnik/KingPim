using KingPim.Application.Repositories.Models;
using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories.Interfaces
{
    public interface IProductRepo
    {
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(int id);
        Task CreateProduct(ProductModel model);
        Task UpdateProduct(ProductModel model);
        Task PublishProduct(ProductModel model);
        Task DeleteProduct(int id);
        IEnumerable<Product> GetAllProductsExport();
    }
}
