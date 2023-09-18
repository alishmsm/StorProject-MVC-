using Store.Application.Interfaces.Contexts;
using Store.Coomon;

namespace Store.Application.Services.Users.Queryes;

public class GetUserService : IGetUserSevice
{
    private readonly IDataBaseContext _context;
    public GetUserService(IDataBaseContext context)
    {
        _context = context;
    }
    public ResaultGetUserDto Execute(RequestGetUserDto request)
    {
        var users = _context.Users.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.SearchKey))
        {
            users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
        }

        int rowCont=0;
        var userList = users.ToPaged(request.Page, 20, out rowCont).Select(p => new GetUserDto
        {
            Email = p.Email,
            Password = p.Password,
            FullName = p.FullName
        }).ToList();

        return new ResaultGetUserDto
        {
            Users = userList,
            Rows = rowCont,
        };
    }
}