using System;
using System.Threading.Tasks;
using KingPim.Application.Account.Service;
using KingPim.Application.Repositories;
using KingPim.Application.Repositories.Interfaces;
using KingPim.Application.Repositories.Models;
using KingPim.Persistence;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    // Apply when app goes live
    // [Authorize]
    [Produces("application/json")]
    [Route("pim/Category/SubCategory/[controller]")]
    public class ProductController : Controller
    {
        //Inject services
        private readonly IProductRepo _productRepo;
        private readonly IUserService _userService;
        private readonly KingPimDbContext _context;

        public ProductController(
            IProductRepo productRepo,
            IUserService userService,
            KingPimDbContext context
            )

        {
            _productRepo = productRepo;
            _userService = userService;
            _context = context;
        }

        // GET: pim/Category/SubCategory/Product
        [HttpGet]

        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productRepo.GetProducts());
        }

        // GET: pim/Category/SubCategory/Product/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product= await _productRepo.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        // POST: pim/Category/SubCategory/Product
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel product)
        {

            product.DateCreated = DateTime.Now;
            product.EditedBy = User.Identity.Name;

            await _productRepo.CreateProduct(product);



            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
        // PUT: pim/Category/SubCategory/Product/1 , Dont work all the way
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductModel product)

         {
            await _productRepo.UpdateProduct(product);
            return NoContent();
        }
        // DELETE: pim/Category/SubCategory/Product/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productRepo.DeleteProduct(id);

            return NoContent();
        }
    }
}