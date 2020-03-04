using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocializR.Models
{
    public class ViewAlbumModel
    {
        public List<PhotoProfileModel> Photos { get; set; }
        public string Name { get; set; }
    }
}
