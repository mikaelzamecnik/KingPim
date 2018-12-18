using System.Text;
using KingPim.Application.Helpers;
using KingPim.Application.Repositories.Interfaces;
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
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly ISubCategoryRepo _subCategoryRepo;


        public ExportController (
            IProductRepo productRepo,
            ICategoryRepo categoryRepo,
            ISubCategoryRepo subCategoryRepo
            )

        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _subCategoryRepo = subCategoryRepo;

        }
        // Export Products to JSON
        [HttpGet]
        [Route("pim/[controller]/Products")]
        public IActionResult GetProductsToJson()
        {


            var products = _productRepo.GetAllProductsExport();
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


            var categories = _categoryRepo.GetAllCategoriesExport();
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


            var subcategories = _subCategoryRepo.GetAllSubCategoriesExport();
            var getSubCategories = ExportHelper.GetSubcategories(subcategories);
            var subcategoryJson = JsonConvert.SerializeObject(getSubCategories);
            var bytes = Encoding.UTF8.GetBytes(subcategoryJson);

            return File(bytes, "application/octet-stream", "subcategories.json");

        }

        // Export SubCategories to JSON
        [HttpGet]
        [Route("pim/[controller]/Catalog")]
        public IActionResult GetCatalogToJson()
        {


            var subcategories = _subCategoryRepo.GetAllSubCategoriesExport();
            var getSubCategories = ExportHelper.GetSubcategories(subcategories);
            var subcategoryJson = JsonConvert.SerializeObject(getSubCategories);

            var categories = _categoryRepo.GetAllCategoriesExport();
            var getCategories = ExportHelper.GetCategories(categories);
            var categoryJson = JsonConvert.SerializeObject(getCategories);

            var products = _productRepo.GetAllProductsExport();
            var getProducts = ExportHelper.GetProducts(products);
            var productJson = JsonConvert.SerializeObject(getProducts);
            var bytes = Encoding.UTF8.GetBytes(categoryJson + subcategoryJson + productJson);


            return File(bytes, "application/octet-stream", "catalog.json");

        }

        // TODO Export Separate items in each product/category/subcategory for angular tree view

    }
    

}
