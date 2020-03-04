using System.Collections.Generic;

namespace BusinessEntities.Entities
{
    public partial class Role
    {
        public Role()
        {
            RolePermission = new HashSet<RolePermission>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RolePermission> RolePermission { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
