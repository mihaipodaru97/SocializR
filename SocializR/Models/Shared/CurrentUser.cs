using System.Collections.Generic;

namespace SocializR.Models
{
    public class CurrentUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<string> Roles { get; set; }
        public bool CanCreateCities { get; set; }
        public bool CanCreateLocalities { get; set; }
        public bool CanDeleteUser { get; set; }
        public bool CanEditProfile { get; set; }
        public bool CanViewProfile { get; set; }
    }
}
