using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KingPim.Persistence;
using Microsoft.AspNetCore.Identity;
using KingPim.Domain.Entities.Identity;
using KingPim.Application.Account;
using KingPim.Web.Helpers;

namespace KingPim.Web.Controllers
{

    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly KingPimDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, IMapper mapper, KingPimDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);
            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.Admins.AddAsync(new Admin { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.Publishers.AddAsync(new Publisher { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.Editors.AddAsync(new Editor { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account Created");
        }
    }
}