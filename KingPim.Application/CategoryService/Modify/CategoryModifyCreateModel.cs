using KingPim.Domain.Entities;

namespace KingPim.Application.CategoryService.Modify
{
    public class CategoryModifyCreateModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CatalogId { get; set; }
        public virtual Domain.Entities.Catalog Catalog { get; set; }
    }
}