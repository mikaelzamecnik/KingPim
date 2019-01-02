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
    [Route("pim/Category/SubCategory/AttributeGroup/[controller]")]
    public class ProductAttributeController : Controller
    {
        //Inject services
        private readonly IProductAttributeRepo _productattributeRepo;
        private readonly IAttributeOptionListRepo _attributeOptionListRepo;
        private readonly IAttributeOptionListValueRepo _attributeOptionListValueRepo;

        public ProductAttributeController
            (IProductAttributeRepo productattributeRepo,
            IAttributeOptionListRepo attributeOptionListRepo,
            IAttributeOptionListValueRepo attributeOptionListValueRepo)

        {
            _productattributeRepo = productattributeRepo;
            _attributeOptionListRepo = attributeOptionListRepo;
            _attributeOptionListValueRepo = attributeOptionListValueRepo;
        }
        // GET: pim/Category/SubCategory/AttributeGroup/ProductAttribute
        [HttpGet]
        public async Task<IActionResult> GetProductattributes()
        {
            return Ok(await _productattributeRepo.GetProductattributes());
        }
        // GET: pim/Category/SubCategory/AttributeGroup/ProductAttribute/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductattribute([FromRoute] int id)
        {
            var att = await _productattributeRepo.GetProductattribute(id);

            if (att == null)
            {
                return NotFound();
            }

            return Ok(att);
        }
        // POST: pim/Category/SubCategory/AttributeGroup/ProductAttribute/
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateProductattribute([FromBody] ProductAttributeModel att)
        {
            await _productattributeRepo.CreateProductattribute(att);
            return CreatedAtAction("GetAttribute", new { id = att.Id }, att);
        }
        // PUT: pim/Category/SubCategory/AttributeGroup/ProductAttribute/1
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateProductattribute([FromRoute] int id, [FromBody] ProductAttributeModel att)
        {
            await _productattributeRepo.UpdateProductattribute(att);
            return NoContent();
        }
        // DELETE: pim/Category/SubCategory/AttributeGroup/ProductAttribute/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductattribute([FromRoute] int id)
        {
            await _productattributeRepo.DeleteProductattribute(id);
            return NoContent();
        }

        // POST: pim/Category/SubCategory/AttributeGroup/ProductAttribute/AttributeOptionList/
        [HttpPost("postattolist")]
        [ValidateModel]
        public async Task<IActionResult> CreateAttributeOptionList([FromBody] AttributeOptionListModel attolist)
        {
            await _attributeOptionListRepo.CreateAttributeOptionList(attolist);
            return CreatedAtAction("GetAttributeOptionList", new { id = attolist.Id }, attolist);
        }

        // POST: pim/Category/SubCategory/AttributeGroup/ProductAttribute/AttributeOptionValueList/
        [HttpPost("postattovaluelist")]
        [ValidateModel]
        public async Task<IActionResult> CreateAttributeOptionValueList([FromBody] AttributeOptionListValueModel attolist)
        {
            await _attributeOptionListValueRepo.CreateAttributeOptionListValue(attolist);
            return CreatedAtAction("GetAttributeOptionList", new { id = attolist.Id }, attolist);
        }

        // GET: pim/Category/SubCategory/AttributeGroup/ProductAttribute
        [HttpGet("getattolist")]
        public async Task<IActionResult> GetAttributeOptionLists()
        {
            return Ok(await _attributeOptionListRepo.GetAttributeOptionLists());
        }

        // GET: pim/Category/SubCategory/AttributeGroup/ProductAttribute
        [HttpGet("getattovaluelist")]
        public async Task<IActionResult> GetAttributeOptionListValues()
        {
            return Ok(await _attributeOptionListValueRepo.GetAttributeOptionListValues());
        }


    }
}