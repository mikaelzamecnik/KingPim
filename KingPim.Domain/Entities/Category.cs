using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string CategoryName { get; set; }
        public int CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public bool PublishedStatus { get; set; }
    }
}
