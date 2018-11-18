using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.ProductService.Modify
{
    public interface IProductModifyPut
    {
        Task Execute(ProductModifyPutModel model);
        //void PublishedStatus(ProductModifyPutModel model);

    }
}