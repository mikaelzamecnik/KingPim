using System;
using System.Threading.Tasks;
using KingPim.Application.Account.Service;
using KingPim.Application.AttributeGroupService.Get;
using KingPim.Application.AttributeGroupService.Modify;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    //Apply when app goes live
   //[Authorize]
    [Produces("application/json")]
    [Route("pim/Category/SubCategory/[controller]")]
    public class AgController : Controller
    {
        //Inject services
        private readonly IAgGetAll _agGetAll;
        private readonly IAgGetSingle _agGetSingle;
        private readonly IAgModifyCreate _agModifyCreate;
        private readonly IAgModifyPut _agModifyPut;
        private readonly IAgModifyDelete _agModifyDelete;
        private readonly IUserService _userService;

        public AgController(
            IAgGetAll agGetAll,
            IAgGetSingle agGetSingle,
            IAgModifyCreate agModifyCreate,
            IAgModifyPut agModifyPut,
            IAgModifyDelete agModifyDelete,
            IUserService userService)

        {
            _agGetAll = agGetAll;
            _agGetSingle = agGetSingle;
            _agModifyCreate = agModifyCreate;
            _agModifyPut = agModifyPut;
            _agModifyDelete = agModifyDelete;
            _userService = userService;

        }

        // GET: pim/Category/SubCategory/AttributeGroup
        [HttpGet]
        public async Task<IActionResult> GetAg()
        {
            return Ok(await _agGetAll.Execute());
        }

        // GET: pim/Category/SubCategory/Attributegroup/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAg([FromRoute] int id)
        {
            var ag= await _agGetSingle.Execute(id);

            if (ag == null)
            {
                return NotFound();
            }

            return Ok(ag);
        }
        // POST: pim/Category/SubCategory/Attributegroup
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> PostAg([FromBody] AgModifyCreateModel ag)
        {
            //var user = _userService.GetAll(HttpContext.User);



            await _agModifyCreate.Execute(ag);



            return CreatedAtAction("GetAttributeGroup", new { id = ag.Id }, ag);
        }
        // PUT: pim/Category/SubCategory/Attributegroup/1
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> PutAg([FromRoute] int id,[FromBody] AgModifyPutModel ag)

         {


           await _agModifyPut.Execute(ag);
            return NoContent();
        }
        // DELETE: pim/Category/SubCategory/Attributegroup/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAg([FromRoute] int id)
        {
            await _agModifyDelete.Execute(id);

            return NoContent();
        }

    }
}