using System;
using System.Threading.Tasks;
using KingPim.Application.ProductService.Get;
using KingPim.Application.ProductService.Modify;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    //Apply when app goes live
   // [Authorize(Roles = "Admin")] 
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

        public ProductController(
            IProductGetAll productGetAll,
            IProductGetSingle productGetSingle,
            IProductModifyCreate productModifyCreate,
            IProductModifyPut productModifyPut,
            IProductModifyDelete productModifyDelete)

        {
            _productGetAll = productGetAll;
            _productGetSingle = productGetSingle;
            _productModifyCreate = productModifyCreate;
            _productModifyPut = productModifyPut;
            _productModifyDelete = productModifyDelete;

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
            var category = await _productGetSingle.Execute(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        // POST: pim/Category/SubCategory/Product
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> PostProduct([FromBody] ProductModifyCreateModel product)
        {
            
            await _productModifyCreate.Execute(product);



            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }
        // PUT: pim/Category/SubCategory/Product/1 , Dont work all the way
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] ProductModifyPutModel product)

        {
            
            await _productModifyPut.Execute(product);



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