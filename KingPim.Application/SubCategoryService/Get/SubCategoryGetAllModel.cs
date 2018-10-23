using System.Collections.Generic;
using KingPim.Domain.Entities;


namespace KingPim.Application.SubCategoryService.Get
{
    public class SubCategoryGetAllModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId {get;set;}
    }
}