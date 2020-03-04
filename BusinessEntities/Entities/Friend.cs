using System;

namespace BusinessEntities.Entities
{
    public partial class Friend
    {
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public DateTime Date { get; set; }

        public User User1 { get; set; }
        public User User2 { get; set; }
    }
}
