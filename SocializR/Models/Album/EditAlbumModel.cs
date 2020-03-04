using System.Collections.Generic;

namespace SocializR.Models
{
    public class EditAlbumModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EditPhotoModel> Photos { get; set; }
    }
}
