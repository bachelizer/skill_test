using System.ComponentModel.DataAnnotations;

namespace skill_test.Models.User;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;
    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
