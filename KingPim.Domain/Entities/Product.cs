using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        public string ProductName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public int Version { get; set; }
        public bool PublishedStatus { get; set; }
        public int? SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        

    }
}