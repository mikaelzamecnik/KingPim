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
    [Route("pim/Category/SubCategory/[controller]")]
    public class AttributeGroupController : Controller
    {
        //Inject services
        private readonly IAttributeGroupRepo _attributeGroupRepo;

        public AttributeGroupController(IAttributeGroupRepo attributeGroupRepo)
        {
            _attributeGroupRepo = attributeGroupRepo;
        }

        // GET: pim/Category/SubCategory/AttributeGroup
        [HttpGet]
        public async Task<IActionResult> GetAttributegroups()
        {
            return Ok(await _attributeGroupRepo.GetAttributegroups());
        }

        // GET: pim/Category/SubCategory/Attributegroup/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttributegroup([FromRoute] int id)
        {
            var ag = await _attributeGroupRepo.GetAttributegroup(id);

            if (ag == null)
            {
                return NotFound();
            }

            return Ok(ag);
        }
        // POST: pim/Category/SubCategory/Attributegroup
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAttributegroup([FromBody] AttributeGroupModel ag)
        {
            //var user = _userService.GetAll(HttpContext.User);


            await _attributeGroupRepo.CreateAttributegroup(ag);



            return CreatedAtAction("GetAttributeGroup", new { id = ag.Id }, ag);
        }
        // PUT: pim/Category/SubCategory/Attributegroup/1
        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> UpdateAttributegroup([FromBody] AttributeGroupModel ag)

         {


           await _attributeGroupRepo.UpdateAttributegroup(ag);
            return NoContent();
        }
        // DELETE: pim/Category/SubCategory/Attributegroup/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttributegroup([FromRoute] int id)
        {
            await _attributeGroupRepo.DeleteAttributegroup(id);

            return NoContent();
        }
        

    }
}