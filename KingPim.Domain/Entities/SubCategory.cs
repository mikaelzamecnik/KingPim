using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class SubCategory
    {
        [ScaffoldColumn(false)]
        public int SubcategoryID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string SubcategoryName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
        public bool PublishedStatus { get; set; }

    }
}
