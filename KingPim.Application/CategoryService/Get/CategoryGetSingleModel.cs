using KingPim.Domain.Entities;

namespace KingPim.Application.CategoryService.Get
{
    public class CategoryGetSingleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubCategory Subcategory { get; set; }
    }
}