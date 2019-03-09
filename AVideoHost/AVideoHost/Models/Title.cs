using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVideoHost.Models
{
    public class Title
    {
        public Title()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public List<TitleItem> Items { get; set; }
        public string TitleDescription { get; set; }
    }
}
