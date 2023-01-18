using skill_test.Models.User;

namespace skill_test.Interfaces;

public interface ILogin
{
    public bool AuthSuperAdmin(string email, string password);
    public Task<User> AuthUser(string email, string password);
}