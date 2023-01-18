using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skill_test.DataContext;
using skill_test.Interfaces;
using skill_test.Models.User;

namespace skill_test.Services.UserService;

public class UserServices : IUser
{
    private readonly skill_set_dbContext _context;

    public UserServices(skill_set_dbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> List()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> View(string? Id)
    {
        return await _context.Users.FirstOrDefaultAsync(m => m.Id == Id);
    }

    public async Task Create(User user)
    {
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }

    }
    public async Task Update(User user)
    {
        try
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

    }
    public async Task Destroy(string? Id)
    {
        try
        {
            var user = await View(Id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }

    }
}