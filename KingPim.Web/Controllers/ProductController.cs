using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Application.Account;
using KingPim.Application.Account.Service;
using KingPim.Application.ProductAttributeValueService;
using KingPim.Application.ProductService.Get;
using KingPim.Application.ProductService.Modify;
using KingPim.Application.SubcategoryAgService;
using KingPim.Domain.Entities;
using KingPim.Persistence;
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
        private readonly KingPimDbContext _context;

        public ProductController(
            IProductGetAll productGetAll,
            IProductGetSingle productGetSingle,
            IProductModifyCreate productModifyCreate,
            IProductModifyPut productModifyPut,
            IProductModifyDelete productModifyDelete,
            IUserService userService,
            KingPimDbContext context
            )

        {
            _productGetAll = productGetAll;
            _productGetSingle = productGetSingle;
            _productModifyCreate = productModifyCreate;
            _productModifyPut = productModifyPut;
            _productModifyDelete = productModifyDelete;
            _userService = userService;
            _context = context;

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
            product.EditedBy = "SuperAdmin";
            product.Version = 1;

            await _productModifyCreate.Execute(product);



            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
        // PUT: pim/Category/SubCategory/Product/1 , Dont work all the way
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] ProductModifyPutModel product)

         {
            // Additonal logic for put request

            product.Id = id;
            product.EditedBy = "SuperAdmin";


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
        [HttpPost("getscag/{id}")]
        public IActionResult GetSubCategoryAttributeGroupList(int id)
        {
            

            SubCategory subCategory = _context.SubCategories.FirstOrDefault(m => m.Id == id);
            List<AttributeGroup> attributeGroups = _context.AttributeGroups.ToList();
            return View( Convert.ToString(subCategory), attributeGroups);
        }

        [HttpPost("getscag")]
        public IActionResult GetSubCategoryAttributeGroupList(SubcategoryAgModel model)
        {
            if (ModelState.IsValid) { 
            var subID = model.SubcategoryId;
            var agID = model.AttributeGroupId;

            IList<SubcategoryAttributeGroup> items = _context.SubcategoryAttributeGroups
                .Where(sa => sa.SubcategoryId == subID)
                .Where(ag => ag.AttributeGroupId == agID).ToList();
            if (items.Count== 0)
            {
                SubcategoryAttributeGroup agItem = new SubcategoryAttributeGroup
                {
                    AttributeGroup = _context.AttributeGroups.Single(c => c.Id == subID),
                    SubCategory = _context.SubCategories.Single(m => m.Id == agID)
                };

                _context.SubcategoryAttributeGroups.Add(agItem);
                _context.SaveChanges();
            }
            }

            return View(model);
        }
        
    }
}