using KingPim.Domain.Entities;

namespace KingPim.Application.CategoryService.Get
{
    public class CategoryGetAllModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CatalogId { get; set; }
        public virtual Domain.Entities.Catalog Catalog { get; set; }
    }
}