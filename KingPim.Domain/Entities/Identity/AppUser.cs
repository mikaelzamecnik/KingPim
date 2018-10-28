﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Domain.Entities.Identity
{
    public class AppUser: IdentityUser
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
    }
}
