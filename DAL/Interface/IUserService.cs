using DAL.Models;

namespace DAL.Interface
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User Login(string email, string password);
        bool RegisterUser(string nickname, string email, string password);
        void BanUser(int id);
    }
}