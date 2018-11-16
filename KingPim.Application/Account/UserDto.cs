using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.Account
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? UserRoleId { get; set; }
        public virtual UserRole UserRoles { get; set; }
        public string Password { get; set; }
    }
}
