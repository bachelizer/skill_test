using Microsoft.EntityFrameworkCore;
using skill_test.DataContext;
using skill_test.Interfaces;
using skill_test.Models.User;

namespace skill_test.Services.LoginServices;

public class LoginServices : ILogin
{
    private readonly skill_set_dbContext _context;

   public LoginServices(skill_set_dbContext context)
    {
        _context = context;
    }

    public bool AuthSuperAdmin(string email, string password)
    {
        const string AdminEmail = "admin@gmail.com";
        const string AdminPassword = "admin";

        return AdminEmail == email && AdminPassword == password;
    }

    public async Task<User> AuthUser(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
    }
}