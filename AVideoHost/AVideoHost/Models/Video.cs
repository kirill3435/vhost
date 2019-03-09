using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVideoHost.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public List<TitleItem> TitleItems { get; set; }
    }
}
