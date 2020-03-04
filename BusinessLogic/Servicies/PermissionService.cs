using BusinessEntities.Types;
using BusinessLogic.Base;
using DataAcces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Servicies
{
    public class PermissionService : BaseService
    {
        public PermissionService(UnitOfWork unitOfWork) 
            :base(unitOfWork)
        {
        }

        public bool CanUserDo(int userId, PermissionType requestedPermission)
        {
            var roles = unitOfWork.UserRole
                .Query()
                .Include(ur => ur.Role)
                    .ThenInclude(r => r.RolePermission)
                .Where(ur => ur.UserId == userId).ToList();

            foreach (var role in roles)
                foreach (var permission in role.Role.RolePermission)
                    if (permission.PermissionId == (int)requestedPermission)
                        return true;

            return false;
        }

        public bool IsAdmin(int id)
        {
            return unitOfWork.UserRole
                .Query()
                .SingleOrDefault(ur => ur.RoleId == (int)RoleType.Admin && ur.UserId == id) != null;
        }
    }
}
