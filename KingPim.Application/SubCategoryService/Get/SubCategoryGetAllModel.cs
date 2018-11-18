using System.Collections.Generic;
using KingPim.Domain.Entities;
using System;


namespace KingPim.Application.SubCategoryService.Get
{
    public class SubCategoryGetAllModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public double Version { get; set; }
        public bool PublishedStatus { get; set; }
        public virtual Category Category { get; set; }
    }
}