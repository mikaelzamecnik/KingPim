using System;
using System.Threading.Tasks;
using KingPim.Application.Account;
using KingPim.Application.Account.Service;
using KingPim.Application.ProductService.Get;
using KingPim.Application.ProductService.Modify;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    //Apply when app goes live
   //[Authorize]
    [Produces("application/json")]
    [Route("pim/Category/SubCategory/[controller]")]
    public class ProductController : Controller
    {
        //Inject services
        private readonly IProductGetAll _productGetAll;
        private readonly IProductGetSingle _productGetSingle;
        private readonly IProductModifyCreate _productModifyCreate;
        private readonly IProductModifyPut _productModifyPut;
        private readonly IProductModifyDelete _productModifyDelete;
        private readonly IUserService _userService;

        public ProductController(
            IProductGetAll productGetAll,
            IProductGetSingle productGetSingle,
            IProductModifyCreate productModifyCreate,
            IProductModifyPut productModifyPut,
            IProductModifyDelete productModifyDelete,
            IUserService userService)

        {
            _productGetAll = productGetAll;
            _productGetSingle = productGetSingle;
            _productModifyCreate = productModifyCreate;
            _productModifyPut = productModifyPut;
            _productModifyDelete = productModifyDelete;
            _userService = userService;

        }

        // GET: pim/Category/SubCategory/Product
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productGetAll.Execute());
        }

        // GET: pim/Category/SubCategory/Product/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product= await _productGetSingle.Execute(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        // POST: pim/Category/SubCategory/Product
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> PostProduct([FromBody] ProductModifyCreateModel product)
        {
            //var user = _userService.GetAll(HttpContext.User);

            product.DateCreated = DateTime.Now;
            product.DateUpdated = DateTime.Now;
            product.EditedBy = "SuperAdmin";
            product.Version = 1;
            product.SubCategoryId = 1;
            await _productModifyCreate.Execute(product);



            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }
        // PUT: pim/Category/SubCategory/Product/1 , Dont work all the way
        [HttpPut("{id}")]
        [ValidateModel]
        public IActionResult PutProduct([FromRoute] int id, [FromBody] ProductModifyPutModel product)

        {
            // Logic for put request

            product.Version = product.Version++;
            product.DateUpdated = DateTime.Now;


            _productModifyPut.Execute(product);
            return NoContent();
        }
        // DELETE: pim/Category/SubCategory/Product/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productModifyDelete.Execute(id);

            return NoContent();
        }

    }
}