using skill_test.Models.User;

namespace skill_test.Interfaces;

public interface IUser
{
    public Task<IEnumerable<User>> List();
    public Task<User> View(string? Id);
    public Task Create(User user);
    public Task Update(User user);
    public Task Destroy(string? Id);
}