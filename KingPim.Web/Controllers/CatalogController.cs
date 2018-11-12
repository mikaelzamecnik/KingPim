using KingPim.Application.Catalog;
using KingPim.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    public class CatalogController
    {
        private ICatalogRepository _catalogRepo;
        private KingPimDbContext _context;
        public CatalogController(ICatalogRepository catalogRepository, KingPimDbContext context)
        {
            _catalogRepo = catalogRepository;
            _context = context;
        }

        // TODO Return List of Category,SubCategories,Products for export in client
        //[HttpGet]
        //public async Task<IActionResult> GetCatalog()

        //}
    }
}
