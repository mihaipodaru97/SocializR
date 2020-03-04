using System.Collections.Generic;

namespace BusinessEntities.Entities
{
    public partial class Album
    {
        public Album()
        {
            Photos = new HashSet<Photo>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
