using System;
using System.Threading.Tasks;
using KingPim.Application.Account.Service;
using KingPim.Application.AttributeGroupService.Get;
using KingPim.Application.AttributeGroupService.Modify;
using KingPim.Application.AttributeService.Get;
using KingPim.Application.AttributeService.Modify;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    //Apply when app goes live
   //[Authorize]
    [Produces("application/json")]
    [Route("pim/Category/SubCategory/AG/[controller]")]
    public class AttributeController : Controller
    {
        //Inject services
        private readonly IAttributeGetAll _attributeGetAll;
        private readonly IAttributeGetSingle _attributeGetSingle;
        private readonly IAttributeModifyCreate _attributeModifyCreate;
        private readonly IAttributeModifyPut _attributeModifyPut;
        private readonly IAttributeModifyDelete _attributeModifyDelete;
        private readonly IUserService _userService;

        public AttributeController(
            IAttributeGetAll attributeGetAll,
            IAttributeGetSingle attributeGetSingle,
            IAttributeModifyCreate attributeModifyCreate,
            IAttributeModifyPut attributeModifyPut,
            IAttributeModifyDelete attributeModifyDelete,
            IUserService userService)

        {
            _attributeGetAll = attributeGetAll;
            _attributeGetSingle = attributeGetSingle;
            _attributeModifyCreate = attributeModifyCreate;
            _attributeModifyPut = attributeModifyPut;
            _attributeModifyDelete = attributeModifyDelete;
            _userService = userService;

        }

        // GET: pim/Category/SubCategory/AG/Attribute
        [HttpGet]
        public async Task<IActionResult> GetAttribute()
        {
            return Ok(await _attributeGetAll.Execute());
        }

        // GET: pim/Category/SubCategory/AG/Attribute/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttribute([FromRoute] int id)
        {
            var att= await _attributeGetSingle.Execute(id);

            if (att == null)
            {
                return NotFound();
            }

            return Ok(att);
        }
        // POST: pim/Category/SubCategory/AG/Attribute
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> PostAttribute([FromBody] AttributeModifyCreateModel att)
        {
            //var user = _userService.GetAll(HttpContext.User);



            await _attributeModifyCreate.Execute(att);



            return CreatedAtAction("GetAttribute", new { id = att.SingleAttributeId }, att);
        }
        // PUT: pim/Category/SubCategory/AG/Attribute/1
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> PutAttribute([FromRoute] int id,[FromBody] AttributeModifyPutModel att)

         {


           await _attributeModifyPut.Execute(att);
            return NoContent();
        }
        // DELETE: pim/Category/SubCategory/AG/Attribute/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute([FromRoute] int id)
        {
            await _attributeModifyDelete.Execute(id);

            return NoContent();
        }

    }
}