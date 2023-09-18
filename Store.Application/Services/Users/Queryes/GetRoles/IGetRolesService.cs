using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.Coomon.DTO;

namespace Bugeto_Store.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResaultDto<List<RolesDto>> Execute();
    }
}
