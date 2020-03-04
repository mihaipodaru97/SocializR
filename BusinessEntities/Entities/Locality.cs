using System.Collections.Generic;

namespace BusinessEntities.Entities
{
    public partial class Locality
    {
        public Locality()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int CountyId { get; set; }
        public string Name { get; set; }

        public County County { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
