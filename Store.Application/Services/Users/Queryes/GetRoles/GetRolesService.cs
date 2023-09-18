using System.Collections.Generic;
using System.Linq;
using Store.Application.Interfaces.Contexts;
using Store.Coomon.DTO;

namespace Bugeto_Store.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;
        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResaultDto<List<RolesDto>> Execute()
        {
            var roles = _context.Roles.ToList().Select(p => new RolesDto
            {
                Id = p.Id,
                Name = p.RoleName,
            }).ToList();

            return new ResaultDto<List<RolesDto>>()
            {
                Data = roles,
                IsSucces = true,
                Message = "",
            };
        }
    }
}
