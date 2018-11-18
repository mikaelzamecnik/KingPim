using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingPim.Application.Account;
using KingPim.Application.Account.Service;
using KingPim.Application.Helpers;
using KingPim.Application.ProductService.Get;
using KingPim.Application.ProductService.Modify;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KingPim.Web.Controllers
{
    //Apply when app goes live
    //[Authorize]
    [Produces("application/json")]
    [Route("pim/[controller]")]
    public class ExportController : Controller
    {
        //Inject services
        private readonly IProductGetAll _productGetAll;


        public ExportController(IProductGetAll productGetAll)

        {
            _productGetAll = productGetAll;

        }

        [HttpGet]
        public IActionResult GetProductsToJson()
        {
           var products = _productGetAll.GetAllProducts();
           var getProducts = ExportHelper.GetProducts(products);
           var productJson = JsonConvert.SerializeObject(getProducts);
           var bytes = Encoding.UTF8.GetBytes(productJson);

           return File(bytes, "application/octet-stream", "products.json");
            
        }

    }
    

}
