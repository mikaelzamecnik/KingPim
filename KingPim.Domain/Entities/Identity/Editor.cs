using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Domain.Entities.Identity
{
    public class Editor
    {
        // Set more options for Editor role account with same AppUser defaults
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }
        public string Location { get; set; }
    }
}
