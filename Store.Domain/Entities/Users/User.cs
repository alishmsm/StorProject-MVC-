namespace Store.Domain.Entities.Users;

public class User
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public virtual ICollection<UserInRole> UserInRoles { get; set; }
}