using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.Repositories.Models
{
    [Serializable]
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public int Version { get; set; }
        public bool PublishedStatus { get; set; }
    }
}
