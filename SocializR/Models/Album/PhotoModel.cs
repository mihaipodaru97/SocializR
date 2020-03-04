using Microsoft.AspNetCore.Http;

namespace SocializR.Models
{
    public class PhotoModel
    {
        public IFormFile Photo { get; set; }
        public string Description { get; set; }
        public int AlbumId { get; set; }
    }
}
