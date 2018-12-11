using KingPim.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.Account.Service
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User ForgotPassword(string username);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
