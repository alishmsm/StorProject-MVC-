using Bugeto_Store.Application.Services.Users.Queries.GetRoles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Users.Queryes;

namespace EndPoint.Site.Areas.Admin.Controllers;

public class UsersController : Controller
{
    private readonly IGetUserSevice _userSevice;
    private readonly IGetRolesService _roleService;
    public UsersController(IGetUserSevice userSevice, IGetRolesService roleService)
    {
        
        _userSevice = userSevice;
        _roleService = roleService;
    }
    // GET
    [Area("Admin")]
    public IActionResult Index(string searchKey,int page=1)
    {
        return View(_userSevice.Execute(new RequestGetUserDto{SearchKey = searchKey, Page = page}));
    }
    [Area("Admin")]
    public IActionResult Create()
    {
        ViewBag.Roles = new SelectList(_roleService.Execute().Data, "Id", "Name");
        return View();
    }
}