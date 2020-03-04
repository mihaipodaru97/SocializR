using System.Collections.Generic;

namespace BusinessEntities.Entities
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermission = new HashSet<RolePermission>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<RolePermission> RolePermission { get; set; }
    }
}
