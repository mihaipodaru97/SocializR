using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities.Entities;

namespace DataAcces.Base
{
    public class DataSeeder
    {
        private Context context;

        public DataSeeder(Context context)
        {
            this.context = context;
        }

        public void InitialDataSeed()
        {
            SeedRoles();
            SeedPermissions();
            SeedRolePermissions();
            SeedCounty();
            context.SaveChanges();
        }

        private void SeedCounty()
        {
            if (context.Counties.Any())
                return;

            var county = new County
            {
                Name = "AdminLand",
                Localities = new List<Locality>
                {
                    new Locality
                    {
                        Name = "AdminLand"
                    }
                }
            };

            context.Counties.Add(county);
        }

        private void SeedRoles()
        {
            if (context.Roles.Any())
                return;

            var roles = new List<Role>
                {
                    new Role {Id = 2, Name = "Member"},
                    new Role {Id = 1, Name = "Administrator"}
                };

            context.AddRange(roles);
        }

        private void SeedPermissions()
        {
            if (context.Permissions.Any())
                return;

            var permissions = new List<Permission>
                {
                    new Permission{Id = 1, Description = "Create county"},
                    new Permission{Id = 2, Description = "Create locality"},
                    new Permission{Id = 3, Description = "Delete user"},
                    new Permission{Id = 4, Description = "Modify profile"},
                    new Permission{Id = 5, Description = "View profile"}
                };

            context.AddRange(permissions);
        }

        private void SeedRolePermissions()
        {
            if (context.RolePermission.Any())
                return;

            var rolePermission = new List<RolePermission>
                {
                    new RolePermission{RoleId = 1, PermissionId = 1},
                    new RolePermission{RoleId = 1, PermissionId = 2},
                    new RolePermission{RoleId = 1, PermissionId = 3},
                    new RolePermission{RoleId = 1, PermissionId = 4},
                    new RolePermission{RoleId = 1, PermissionId = 5}
                };

            context.AddRange(rolePermission);
        }
    }
}
