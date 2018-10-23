using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Application.CategoryService.Get;
using KingPim.Application.CategoryService.Modify;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Produces("application/json")]
    [Route("pim/[controller]")]
    public class CategoryController : Controller
    {
        //Inject services
        private readonly ICategoryGetAll _categoryGetAll;
        private readonly ICategoryGetSingle _categoryGetSingle;
        private readonly ICategoryModifyCreate _categoryModifyCreate;
        private readonly ICategoryModifyPut _categoryModifyPut;
        private readonly ICategoryModifyDelete _categoryModifyDelete;

        public CategoryController(
            ICategoryGetSingle categoryGetSingle,
            ICategoryGetAll categoryGetAll,
            ICategoryModifyCreate categoryModifyCreate,
            ICategoryModifyPut categoryModifyPut,
            ICategoryModifyDelete categoryModifyDelete)
        {
            _categoryGetAll = categoryGetAll;
            _categoryGetSingle = categoryGetSingle;
            _categoryModifyCreate = categoryModifyCreate;
            _categoryModifyPut = categoryModifyPut;
            _categoryModifyDelete = categoryModifyDelete;
        }

        // GET: pim/Category/
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryGetAll.Execute());
        }

        // GET: pim/Category/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var category = await _categoryGetSingle.Execute(id);

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
        }

    }
}