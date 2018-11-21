using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingPim.Application.Account;
using KingPim.Application.Account.Service;
using KingPim.Application.CategoryService.Get;
using KingPim.Application.Helpers;
using KingPim.Application.ProductService.Get;
using KingPim.Application.ProductService.Modify;
using KingPim.Application.SubCategoryService.Get;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KingPim.Web.Controllers
{
    //Apply when app goes live
    //[Authorize]
    [Produces("application/json")]
    public class ExportController : Controller
    {
        //Inject services
        private readonly IProductGetAll _productGetAll;
        private readonly ICategoryGetAll _categoryGetAll;
        private readonly ISubCategoryGetAll _subCategoryGetAll;


        public ExportController(IProductGetAll productGetAll,
            ICategoryGetAll categoryGetAll,
            ISubCategoryGetAll subCategoryGetAll
            )

        {
            _productGetAll = productGetAll;
            _categoryGetAll = categoryGetAll;
            _subCategoryGetAll = subCategoryGetAll;

        }
        // Export Products to JSON
        [HttpGet]
        [Route("pim/[controller]/Products")]
        public IActionResult GetProductsToJson()
        {


            var products = _productGetAll.GetAllProducts();
            var getProducts = ExportHelper.GetProducts(products);
            var productJson = JsonConvert.SerializeObject(getProducts);
            var bytes = Encoding.UTF8.GetBytes(productJson);

            return File(bytes, "application/octet-stream", "products.json");

        }
        // Export Categories to JSON
        [HttpGet]
        [Route("pim/[controller]/Categories")]
        public IActionResult GetCategoriesToJson()
        {


            var categories = _categoryGetAll.GetAllCategories();
            var getCategories = ExportHelper.GetCategories(categories);
            var categoryJson = JsonConvert.SerializeObject(getCategories);
            var bytes = Encoding.UTF8.GetBytes(categoryJson);

            return File(bytes, "application/octet-stream", "categories.json");

        }
        // Export SubCategories to JSON
        [HttpGet]
        [Route("pim/[controller]/SubCategories")]
        public IActionResult GetSubCategoriesToJson()
        {


            var subcategories = _subCategoryGetAll.GetAllSubCategories();
            var getSubCategories = ExportHelper.GetSubCategories(subcategories);
            var subcategoryJson = JsonConvert.SerializeObject(getSubCategories);
            var bytes = Encoding.UTF8.GetBytes(subcategoryJson);

            return File(bytes, "application/octet-stream", "subcategories.json");

        }

        // TODO Export Separate items in each product/category/subcategory

    }
    

}
