using Store.Application.Interfaces.Contexts;
using Store.Coomon.DTO;
using Store.Domain.Entities.Users;

namespace Store.Application.Services.Users.Commands.RegisterUser;

public interface IRegisterUser
{
    ResaultDto<ResaultRegisterDto> Execute(RequestRegisterDto request);
}

public class RegisterUser : IRegisterUser
{
    private readonly IDataBaseContext _context;

    public RegisterUser(IDataBaseContext context)
    {
        _context = context;
    }
    
    public ResaultDto<ResaultRegisterDto> Execute(RequestRegisterDto request)
    {
        User user = new User()
        {
            Email = request.Email,
            FullName = request.FullName,
          
        };

        List<UserInRole> userInRoles = new();
        foreach (var item in request.roles)
        {
            var role = _context.Roles.Find(item.Id);
            userInRoles.Add(new UserInRole
            {
                Role = role,
                RoleId = role.Id,
                User = user,
                UserId = user.Id,
            });
            
            
        }
        user.UserInRoles = userInRoles;
        
        return new ResaultDto<ResaultRegisterDto>()
        {
            Data = new ResaultRegisterDto()
            {
                UserId = user.Id,

            },
            IsSucces = true,
            Message = "ثبت نام کاربر انجام شد",
        };
    }
}

public class RequestRegisterDto
{
    public string FullName { get; set; }
    public string Email { get; set; }

    public List<RolesInRgegisterUserDto> roles { get; set; }
}
public class RolesInRgegisterUserDto
{
    public long Id { get; set; }
}

public class ResaultRegisterDto
{
    public long UserId { get; set; }
}

