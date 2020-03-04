using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocializR.Models
{
    public class EditProfileModel
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numele trebuie sa aiba intre 5 si 50 caractere")]
        [RegularExpression("^[A-Za-z][A-Za-z0-9]*", ErrorMessage = "Nume invalid")]
        [Required(ErrorMessage = "Camp obligatoriu")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numele trebuie sa aiba intre 5 si 50 caractere")]
        [RegularExpression("^[A-Za-z][A-Za-z0-9]*", ErrorMessage = "Nume invalid")]
        [Required(ErrorMessage = "Camp obligatoriu")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Camp obligatoriu")]

        [DisplayName("City")]
        public int CountyId { get; set; }
        public List<SelectListItem> Counties { get; set; }

        [DisplayName("Locality")]
        public int LocalityId { get; set; }
        public List<SelectListItem> Localities { get; set; }
        public DateTime Birthday { get; set; }

        [Required]
        public string Privacy { get; set; }

        [Required]
        public string Gender { get; set; }

        public IFormFile ProfilePhoto { get; set; }

        public int Id { get; set; }
        public List<int> Interests { get; set; }
    }
}
