﻿using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.Account.Service
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
