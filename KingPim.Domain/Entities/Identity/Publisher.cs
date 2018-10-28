using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Domain.Entities.Identity
{
    public class Publisher
    {
        // Set more options for Publisher role account with same AppUser defaults
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }
        public string Location { get; set; }
    }
}
