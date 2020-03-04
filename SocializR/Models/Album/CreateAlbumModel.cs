using System.ComponentModel.DataAnnotations;

namespace SocializR.Models
{
    public class CreateAlbumModel
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numele trebuie sa aiba intre 3 si 50 caractere")]
        [RegularExpression("^[A-Za-z][A-Za-z0-9 ]*", ErrorMessage = "Nume invalid")]
        [Required(ErrorMessage = "Camp obligatoriu")]
        public string Name { get; set; }
    }
}
