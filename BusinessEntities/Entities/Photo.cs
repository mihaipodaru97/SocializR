using System.Collections.Generic;

namespace BusinessEntities.Entities
{
    public partial class Photo
    {
        public int Id { get; set; }
        public int? AlbumId { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public Album Album { get; set; }
    }
}
