using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AVideoHost.Models;

namespace AVideoHost.ViewModels
{
    public class TitleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string TitleDescription { get; set; }
        public List<TitleItemViewModel> Items { get; set; }
    }

    public class TitleItemViewModel
    {
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }
    }
}
