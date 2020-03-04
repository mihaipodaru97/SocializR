using System.Collections.Generic;

namespace BusinessEntities.Entities
{
    public partial class Interest
    {
        public Interest()
        {
            UserInterest = new HashSet<UserInterest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserInterest> UserInterest { get; set; }
    }
}
