using KingPim.Domain.Entities;

namespace KingPim.Application.SubCategoryService.Modify
{
    public class SubCategoryModifyCreateModel
    {
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}