using System.Threading.Tasks;
using KingPim.Application.Repositories.Interfaces;
using KingPim.Application.Repositories.Models;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    // Apply when app goes live
    // [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("pim/Category/[controller]")]
    public class SubCategoryController : Controller
    {
        //Inject services
        private readonly ISubCategoryRepo _subcategoryRepo;
        public SubCategoryController(ISubCategoryRepo subcategoryRepo)
        {
            _subcategoryRepo = subcategoryRepo;
        }

        // GET: pim/Category/SubCategory
        [HttpGet]
        public async Task<IActionResult> GetSubcategories()
        {
            return Ok(await _subcategoryRepo.GetSubcategories());
        }

        // GET: pim/Category/SubCategory/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubcategory([FromRoute] int id)
        {
            var subcategory = await _subcategoryRepo.GetSubcategory(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            return Ok(subcategory);
        }
        // POST: pim/Category/SubCategory
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateSubcategory([FromBody] SubCategoryModel subcategory)
        {


            await _subcategoryRepo.CreateSubcategory(subcategory);
            return CreatedAtAction("GetSubCategory", new { id = subcategory.Id }, subcategory);
        }
        // PUT: pim/Category/SubCategory/1 , Dont work all the way
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateSubcategory([FromRoute] int id, [FromBody] SubCategoryModel subcategory)
        {
            await _subcategoryRepo.UpdateSubcategory(subcategory);

            return NoContent();
        }
        // DELETE: pim/Category/SubCategory/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubcategory([FromRoute] int id)
        {
            await _subcategoryRepo.DeleteSubcategory(id);

            return NoContent();
        }

    }
}