using System.Linq;
using System.Threading.Tasks;
using KingPim.Application.Helpers;
using KingPim.Application.SubCategoryService.Get;
using KingPim.Application.SubCategoryService.Modify;
using KingPim.Domain.Entities;
using KingPim.Persistence;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
        //Apply when app goes live
        // [Authorize(Roles = "Admin")] 
        [Produces("application/json")]
        [Route("pim/Category/[controller]")]
        public class SubCategoryController : Controller
        {
            //Inject services
            private readonly ISubCategoryGetAll _subcategoryGetAll;
            private readonly ISubCategoryGetSingle _subcategoryGetSingle;
            private readonly ISubCategoryModifyCreate _subcategoryModifyCreate;
            private readonly ISubCategoryModifyPut _subcategoryModifyPut;
            private readonly ISubCategoryModifyDelete _subcategoryModifyDelete;
            

            public SubCategoryController(
                ISubCategoryGetSingle subcategoryGetSingle,
                ISubCategoryGetAll subcategoryGetAll,
                ISubCategoryModifyCreate subcategoryModifyCreate,
                ISubCategoryModifyPut subcategoryModifyPut,
                ISubCategoryModifyDelete subcategoryModifyDelete)
            {
                _subcategoryGetAll = subcategoryGetAll;
                _subcategoryGetSingle = subcategoryGetSingle;
                _subcategoryModifyCreate = subcategoryModifyCreate;
                _subcategoryModifyPut = subcategoryModifyPut;
                _subcategoryModifyDelete = subcategoryModifyDelete;
            }

            // GET: pim/Category/SubCategory
            [HttpGet]
            public async Task<IActionResult> GetSubCategories()
            {
                return Ok(await _subcategoryGetAll.Execute());
            }

            // GET: pim/Category/SubCategory/1
            [HttpGet("{id}")]
            public async Task<IActionResult> GetSubCategory([FromRoute] int id)
            {
                var subcategory = await _subcategoryGetSingle.Execute(id);

                if (subcategory == null)
                {
                    return NotFound();
                }

                return Ok(subcategory);
            }
            // POST: pim/Category/SubCategory
            [HttpPost]
            [ValidateModel]
            public async Task<IActionResult> PostSubCategory([FromBody] SubCategoryModifyCreateModel subcategory)
            {


                await _subcategoryModifyCreate.Execute(subcategory);
                return Json(subcategory);
            }
            // PUT: pim/Category/SubCategory/1 , Dont work all the way
            [HttpPut("{id}")]
            [ValidateModel]
            public async Task<IActionResult> PutSubCategory([FromRoute] int id, [FromBody] SubCategoryModifyPutModel subcategory)
            {
                await _subcategoryModifyPut.Execute(subcategory);

                return NoContent();
            }
            // DELETE: pim/Category/SubCategory/1
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteSubCategory([FromRoute] int id)
            {
                await _subcategoryModifyDelete.Execute(id);

                return NoContent();
            }

    }
}