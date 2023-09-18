namespace Store.Application.Services.Users.Queryes;

public interface IGetUserSevice
{
    ResaultGetUserDto Execute(RequestGetUserDto Request);
}