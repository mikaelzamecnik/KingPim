using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Application.ProductService.Get;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Produces("application/json")]
    [Route("pim/Category/SubCategory/[controller]")]
    public class ProductController : Controller
    {
        //Inject services
        private readonly IProductGetAll _productGetAll;

        public ProductController(
            IProductGetAll productGetAll)

        {
            _productGetAll = productGetAll;

        }

        // GET: pim/Category/
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productGetAll.Execute());
        }

        // GET: pim/Category/1
        /* [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var category = await _productGetSingle.Execute(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
         // POST: pim/Category
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> PostCategory([FromBody] CategoryModifyCreateModel category)
        {

            await _categoryModifyCreate.Execute(category);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }
        // PUT: pim/Category/1 , Dont work all the way
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] CategoryModifyPutModel category)
        {
            await _categoryModifyPut.Execute(category);

            return NoContent();
        }
        // DELETE: pim/Category/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            await _categoryModifyDelete.Execute(id);

            return NoContent();
        } */

    }
}