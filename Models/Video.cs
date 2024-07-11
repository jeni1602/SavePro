// Models/Video.cs
using System.ComponentModel.DataAnnotations;

namespace SavePro.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
    }

}

