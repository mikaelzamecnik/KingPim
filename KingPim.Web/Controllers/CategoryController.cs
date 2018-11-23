using System.Threading.Tasks;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using KingPim.Application.Repositories.Interfaces;
using KingPim.Application.Repositories.Models;

namespace KingPim.Web.Controllers
{
    // Apply when app goes live
    // [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("pim/[controller]")]
    public class CategoryController : Controller
    {
        //Inject services
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        // GET: pim/Category/
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryRepo.GetCategories());
        }

        // GET: pim/Category/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var category = await _categoryRepo.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        // POST: pim/Category
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryModel category)
        {
            await _categoryRepo.CreateCategory(category);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }
        // PUT: pim/Category/1 , Dont work all the way
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryModel category)
        {
            await _categoryRepo.UpdateCategory(category);

            return NoContent();
        }
        // DELETE: pim/Category/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            await _categoryRepo.DeleteCategory(id);

            return NoContent();
        }

    }
}
