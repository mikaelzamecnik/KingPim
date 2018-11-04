using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class ProductSystemValue
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public string Version { get; set; }
        public bool PublishedStatus { get; set; }
    }
}
