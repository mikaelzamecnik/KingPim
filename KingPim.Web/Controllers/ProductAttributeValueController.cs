using System.Threading.Tasks;
using KingPim.Application.Repositories.Interfaces;
using KingPim.Application.Repositories.Models;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    // Apply when app goes live
    // [Authorize]
    [Produces("application/json")]
    [Route("pim/Category/SubCategory/AttributeGroup/ProductAttribute/[controller]")]
    public class ProductAttributeValueController : Controller
    {
        //Inject services
        private readonly IProductAttributeValueRepo _productattributevalueRepo;

        public ProductAttributeValueController(IProductAttributeValueRepo productattributevalueRepo)

        {
            _productattributevalueRepo = productattributevalueRepo;
        }
        // GET: pim/Category/SubCategory/AttributeGroup/ProductAttribute
        [HttpGet]
        public async Task<IActionResult> GetProductattributevalues()
        {
            return Ok(await _productattributevalueRepo.GetProductattributevalues());
        }
        // GET: pim/Category/SubCategory/AttributeGroup/ProductAttribute/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductattributevalue([FromRoute] int id)
        {
            var att = await _productattributevalueRepo.GetProductattributevalue(id);

            if (att == null)
            {
                return NotFound();
            }

            return Ok(att);
        }
        // POST: pim/Category/SubCategory/AttributeGroup/ProductAttribute/
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateProductattributevalue([FromBody] ProductAttributeValuesModel attval)
        {


            await _productattributevalueRepo.CreateProductattributevalue(attval);
            return CreatedAtAction("GetAttributeValue", new { id = attval.Id }, attval);
        }
        // PUT: pim/Category/SubCategory/AttributeGroup/ProductAttribute/1
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateProductattributevalue([FromRoute] int id, [FromBody] ProductAttributeValuesModel att)
        {
            await _productattributevalueRepo.UpdateProductattributevalue(att);
            return NoContent();
        }
        // DELETE: pim/Category/SubCategory/AttributeGroup/ProductAttribute/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductattributevalue([FromRoute] int id)
        {
            await _productattributevalueRepo.DeleteProductattributevalue(id);
            return NoContent();
        }

    }
}