using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class SystemValues
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public double Version { get; set; }
        public bool PublishedStatus { get; set; }
    }
}
