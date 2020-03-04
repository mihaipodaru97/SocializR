using System.Collections.Generic;

namespace BusinessEntities.Entities
{
    public partial class County
    {
        public County()
        {
            Localities = new HashSet<Locality>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Locality> Localities { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
